using Microsoft.EntityFrameworkCore;

using Tickets.BL;
using Tickets.BL.Managers.Departments;
using Tickets.BL.Managers.Developers;
using Tickets.BL.Managers.Tickets;
using Tickets.DAL;
using Tickets.DAL.Data.Context;
using Tickets.DAL.Repos.Departments;
using Tickets.DAL.Repos.Developers;
using Tickets.DAL.Repos.Tickets;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#region Database

var connectionString = builder.Configuration.GetConnectionString("TicketCon");
builder.Services.AddDbContext<TicketsContext>(options
    => options.UseSqlServer(connectionString));

#endregion

#region Repos

builder.Services.AddScoped<IDevelopersRepo, DevelopersRepo>();
builder.Services.AddScoped<ITicketsRepo, TicketsRepo>();
builder.Services.AddScoped<IDepartmentsRepo, DepartmentsRepo>();

#endregion

#region Managers

builder.Services.AddScoped<IDevelopersManager, DevelopersManager>();
builder.Services.AddScoped<ITicketsManager, TicketsManager>();
builder.Services.AddScoped<IDepartmentsManager, DepartmentsManager>();

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
