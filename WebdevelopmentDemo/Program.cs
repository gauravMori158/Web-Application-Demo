using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using WebdevelopmentDemo.Interface;
using WebdevelopmentDemo.Models;
using WebdevelopmentDemo.Repository;
using WebdevelopmentDemo.Validation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var services = builder.Services;
services.AddDbContext<DbContextClass>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));
services.AddScoped<IValidator<Product>, FluentValidationClass>();
services.AddScoped<IProductRepo, ProductRepo>();
services.AddScoped<ICategoryRepo, CategoryRepo>();
services.AddScoped<IOrderRepo, OrderRepo>();

services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
{
    option.LoginPath = "/Account/Login";
    option.Cookie.Name = "AuthCookie";

});

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
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();
