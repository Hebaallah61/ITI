using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using task1.RepoServices;
using Microsoft.AspNetCore.Identity;

using task1.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MeDBContext>(op =>
            op.UseSqlServer(builder.Configuration.GetConnectionString("myConn")));

builder.Services.AddDefaultIdentity<UApp>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<MeDBContext>();
builder.Services.AddScoped<ICourse,CourseRepo>();
builder.Services.AddScoped<ITrainee,TraineeRepo>();
builder.Services.AddScoped<ITrack,TrackRepo>();

//builder.Services.AddIdentity<UApp, IdentityRole>(options =>
//{
//    options.User.RequireUniqueEmail = false;
//});
//builder.Services.AddTransient<UApp>();
//.AddDefaultTokenProviders();

// Add application services.


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
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );
app.MapRazorPages();

app.Run();
