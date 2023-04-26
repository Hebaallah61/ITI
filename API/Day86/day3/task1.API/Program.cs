using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using task1.API.Data.Context;
using task1.API.Data.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



#region Database

var connectionString = builder.Configuration.GetConnectionString("MyCon");
builder.Services.AddDbContext<MyContext>(options =>
    options.UseSqlServer(connectionString));

#endregion

#region Identity Managers

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequiredUniqueChars = 3;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;

    options.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<MyContext>();

#endregion

#region Authentication

builder.Services.AddAuthentication(options =>
{
    //Used Authentication Scheme
    options.DefaultAuthenticateScheme = "UserAuthentication";

    //Used Challenge Authentication Scheme
    options.DefaultChallengeScheme = "UserAuthentication";
})
    .AddJwtBearer("UserAuthentication", options =>
    {
        var secretKeyString = builder.Configuration.GetValue<string>("SecretKey") ?? string.Empty;
        var secretKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString);
        var secretKey = new SymmetricSecurityKey(secretKeyInBytes);

        options.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = secretKey,
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });

#endregion

#region Authorization

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AllowAdmin", policy => policy
        .RequireClaim(ClaimTypes.Role, "Admin")
        .RequireClaim(ClaimTypes.NameIdentifier));

    options.AddPolicy("AllowUser", policy => policy
        .RequireClaim(ClaimTypes.Role, "Admin", "User","Instructor")
        .RequireClaim(ClaimTypes.NameIdentifier));
});

#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
