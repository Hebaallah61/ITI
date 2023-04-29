using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using task1.Pages.Track;
using task1.Pages.Trainee;
using task1.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using task1.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("task1ContextConnection") ?? throw new InvalidOperationException("Connection string 'task1ContextConnection' not found.");

builder.Services.AddDbContext<task1Context>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<task1Context>();

//for logout 
builder.Services.AddAuthentication("Identity.Application").AddCookie();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddHttpClient<ITrainee, TraineeDB>(
    client => client.BaseAddress = new Uri("https://localhost:7095/"));

builder.Services.AddHttpClient<ITrack, TrackDB>(
    client => client.BaseAddress = new Uri("https://localhost:7095/"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();//----------------
app.MapBlazorHub();//signalr connection
app.MapFallbackToPage("/_Host");

app.Run();
