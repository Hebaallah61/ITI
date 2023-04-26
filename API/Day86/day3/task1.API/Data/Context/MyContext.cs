using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data.Common;
using task1.API.Data.Models;

namespace task1.API.Data.Context;

public class MyContext : IdentityDbContext<User>
{
    public MyContext(DbContextOptions<MyContext> option):base(option){ }
    public DbSet<Instructor> Instructors => Set<Instructor>();
    public DbSet<Department> Departments => Set<Department>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);


        builder.Entity<Department>().HasData(
            new Department
            {
                Id = 1,
                Name = "Computer Science",
                Description = "The department of computer science",
                Branches = "CS, IT",
                Location = "Building 1, Floor 2"
            },
            new Department
            {
                Id = 2,
                Name = "Business Administration",
                Description = "The department of business administration",
                Branches = "BA, MBA",
                Location = "Building 2, Floor 1"
            },
             new Department
             {
                 Id = 3,
                 Name = "Engineering",
                 Description = "The department of engineering",
                 Branches = "Civil, Mechanical, Electrical",
                 Location = "Building 3, Floor 3"
             }
            );

        builder.Entity<Instructor>().HasData(
             new Instructor
             {
                 Id = 1,
                 Name = "John Doe",
                 Email = "johndoe@example.com",
                 Phone = "123-456-7890",
                 SSN = "123-45-6789",
                 Age = 30,
                 Address = "123 Main St",
                 Salary = 50000.00,
                 DOB = new DateTime(1993, 1, 1),
                 Password = "password",
                 DepartmentId = 1
             },
            new Instructor
            {
                Id = 2,
                Name = "Jane Smith",
                Email = "janesmith@example.com",
                Phone = "987-654-3210",
                SSN = "987-65-4321",
                Age = 40,
                Address = "456 Elm St",
                Salary = 60000.00,
                DOB = new DateTime(1983, 1, 1),
                Password = "password",
                DepartmentId = 2
            },
             new Instructor
             {
                 Id = 3,
                 Name = "Bob Johnson",
                 Email = "bobjohnson@example.com",
                 Phone = "555-555-1212",
                 SSN = "111-11-1111",
                 Age = 50,
                 Address = "789 Maple St",
                 Salary = 70000.00,
                 DOB = new DateTime(1973, 1, 1),
                 Password = "password",
                 DepartmentId = 1
             },
            new Instructor
            {
                Id = 4,
                Name = "Samantha Lee",
                Email = "samlee@example.com",
                Phone = "555-555-2323",
                SSN = "222-22-2222",
                Age = 35,
                Address = "234 Oak St",
                Salary = 55000.00,
                DOB = new DateTime(1988, 1, 1),
                Password = "password",
                DepartmentId = 3
            }
            );
    }

    

}
