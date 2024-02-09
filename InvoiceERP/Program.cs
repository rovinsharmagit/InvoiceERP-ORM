using InvoiceERP.iDbContext;
using InvoiceERP.IFilters;
using InvoiceERP.IRepositories;
using InvoiceERP.IServices;
using InvoiceERP.IEncryptionService;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using InvoiceERP.IUrlEncryptionMiddleware;

var builder = WebApplication.CreateBuilder(args);

// Generate the encryption key
var aes = Aes.Create();
aes.KeySize = 256;
aes.GenerateKey();
var encryptionKey = Convert.ToBase64String(aes.Key);

// Update the environment variable with the generated key
Environment.SetEnvironmentVariable("ENCRYPTION_KEY", encryptionKey);

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<MyAuthorizationFilter>(); // Register the filter globally
});

builder.Services.AddDbContext<IDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnections")));

// Register the EncryptUri service
builder.Services.AddSingleton<EncryptUri>();

builder.Services.AddScoped<IUserTypeService, UserTypeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Add middleware for URL encryption and decryption
app.UseMiddleware<UrlEncryptionMiddleware>();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
