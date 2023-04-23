using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tickets.DAL.Data.Models;

namespace Tickets.DAL.Data.Context;

public class TicketsContext:DbContext
{
    public TicketsContext(DbContextOptions<TicketsContext> options):base(options){ }
    public DbSet<Ticket> Tickets => Set<Ticket>();
    public DbSet<Developer> Developers => Set<Developer>();
    public DbSet<Department> Departments => Set<Department>();

   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        // Department seeding
        modelBuilder.Entity<Department>().HasData(
            new Department { Id = 1, Name = "Marketing" },
            new Department { Id = 2, Name = "Development" },
            new Department { Id = 3, Name = "Human Resources" }
        );

        // Developer seeding
        modelBuilder.Entity<Developer>().HasData(
            new Developer { Id = 1, Name = "John" },
            new Developer { Id = 2, Name = "Mary" },
            new Developer { Id = 3, Name = "Peter" }
        );

        // Ticket seeding
        modelBuilder.Entity<Ticket>().HasData(
            new Ticket { Id = 1, Title = "Bug fix for website", Description = "Fix the issue with the login page", DepartmentId = 2 },
            new Ticket { Id = 2, Title = "New landing page design", Description = "Create a new landing page design for the marketing department", DepartmentId = 1 },
            new Ticket { Id = 3, Title = "Recruiting software", Description = "Develop a new software for the HR department to manage job applications", DepartmentId = 3 }
        );

        
    }
}
