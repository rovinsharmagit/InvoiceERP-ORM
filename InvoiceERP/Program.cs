using InvoiceERP.iDbContext;
using InvoiceERP.IFilters;
using InvoiceERP.IRepositories;
using InvoiceERP.IServices;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<MyAuthorizationFilter>(); // Register the filter globally
});

builder.Services.AddDbContext<IDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnections")));

builder.Services.AddScoped<IUserTypeService, UserTypeService>();

builder.Services.AddHttpsRedirection(options =>
{
    options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
    options.HttpsPort = 7130;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseCookiePolicy(
   new CookiePolicyOptions
   {
       Secure = CookieSecurePolicy.Always,
       HttpOnly = HttpOnlyPolicy.Always
   });

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();