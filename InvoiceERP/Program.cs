
using InvoiceERP.iDbContext;
using InvoiceERP.IRepositories;
using InvoiceERP.IServices;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<IDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnections")));
builder.Services.AddScoped<IUserTypeService, UserTypeService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=UserTypes}/{action=Index}/{id?}");

app.Run();
