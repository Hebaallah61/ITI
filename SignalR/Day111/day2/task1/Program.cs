using Microsoft.EntityFrameworkCore;
using System.Configuration;
using task1.MyDB;
using Microsoft.Extensions.Configuration;
using task1.Hubs;
using task1.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("MyDBConnection");

builder.Services.AddDbContext<MyDBContext>(options =>
    options.UseSqlServer(connectionString));
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSignalR();
builder.Services.AddCors(opt =>

               opt.AddDefaultPolicy(policy =>
                   policy.WithOrigins("http://127.0.0.1:62385").AllowAnyMethod()
                   .AllowAnyHeader().AllowCredentials()
               )
           );

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

app.MapHub<Buy>("Buy");
app.MapHub<Comments>("Comments");
app.MapHub<NewProduct>("NewProduct");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id?}");

app.Run();
