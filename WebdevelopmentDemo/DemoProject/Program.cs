using DemoProject.Interface;
using DemoProject.Models;
using DemoProject.Repository;
using DemoProject.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddFluentValidation();
builder.Services.AddScoped<IValidator<Employee>, EmployeeValidator>();

LoggerConfiguration loggerConfiguration = new LoggerConfiguration();
builder.Host.UseSerilog((context,configuration) => configuration.ReadFrom.Configuration(context.Configuration));
Log.Logger = loggerConfiguration.MinimumLevel.Override("Microsoft", LogEventLevel.Information).Enrich.FromLogContext().WriteTo.Console().CreateLogger();

builder.Services.Configure<StaticFileOptions>(options =>
{
    options.OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers["Cache-Control"] = "public,max-age=3600";
    };
});
builder.Services.AddDbContext<EmployeeDBContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DemoProjectDBCS")));
builder.Services.AddScoped<IEmployee,EmployeeRepository>();
builder.Services.AddScoped<IDepartment,DepartmentRepository>();
builder.Services.AddScoped<IProject,ProjectRepository>();

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
app.UseSerilogRequestLogging();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=Index}/{id?}");

app.Run();
