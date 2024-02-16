using InvoiceERP.iDbContext;
using InvoiceERP.IFilters;
using InvoiceERP.IMiddlewares;
using InvoiceERP.IRepositories;
using InvoiceERP.IServices;
using InvoiceERP.Services;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<MyAuthorizationFilter>(); // Register the filter globally
});

builder.Services.AddDbContext<IDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnections")));

// Configure AntiForgery service
builder.Services.AddAntiforgery(options =>
{
    options.HeaderName = "X-XSRF-TOKEN"; // Change header name if needed
});

builder.Services.AddSession(options =>
{
    // Set a short timeout for easy testing
    options.IdleTimeout = TimeSpan.FromMinutes(5);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true; // Make the session cookie essential
});

// Configure SameSite attribute and Secure flag for all cookies
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.Lax;
    options.Secure = builder.Environment.IsDevelopment() ? CookieSecurePolicy.None : CookieSecurePolicy.None;
});

builder.Services.AddScoped<IUserTypeService, UserTypeService>();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddSingleton<IJwtService>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    var secretKey = configuration["Jwt:SecretKey"];
    var issuer = configuration["Jwt:Issuer"];
    var audience = configuration["Jwt:Audience"];
    // Check for null values and provide defaults if necessary
    secretKey ??= "defaultSecretKey";
    issuer ??= "defaultIssuer";
    audience ??= "defaultAudience";

    return new JwtService(secretKey, issuer, audience);
});

// Add login service
builder.Services.AddScoped<ILoginService, LoginService>();

// Configure logging
builder.Logging.ClearProviders(); // Clear any existing logging providers

builder.Logging.AddConsole(); // Add console logging
builder.Logging.AddDebug(); // Add debug logging


var app = builder.Build();

// Configure JWT authentication
var jwtService = app.Services.GetRequiredService<IJwtService>();
var secretKey = app.Configuration["Jwt:SecretKey"];
var keyBytes = string.IsNullOrEmpty(secretKey) ? Array.Empty<byte>() : Encoding.UTF8.GetBytes(secretKey); // Use UTF8 encoding
var tokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateIssuerSigningKey = true,
    ValidIssuer = app.Configuration["Jwt:Issuer"],
    ValidAudience = app.Configuration["Jwt:Audience"],
    IssuerSigningKey = new SymmetricSecurityKey(keyBytes), // Use the byte array directly
    ClockSkew = TimeSpan.Zero // Remove clock skew
};

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.Use(async (context, next) =>
{
    context.Response.GetTypedHeaders().CacheControl =
        new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
        {
            NoCache = true,
            NoStore = true,
            MustRevalidate = true
        };
    context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Pragma] = new string[] { "no-cache" };
    context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Expires] = new string[] { "0" };
    await next();
});
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthorization();
app.UseMiddleware<ValidateTokenMiddleware>();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();