using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.Entities;
using test.Configrations;
using LiteDB;

namespace test.Context
{
    internal class EmployeeContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EmployeeMigrateExample;Integrated Security=True;Encrypt=false");


        //3. Fluent API 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Original Style for Fluent API

            //modelBuilder.Entity<Employee>()

            //    .HasKey(E=>E.EId);

            //modelBuilder.Entity<Employee>().Property(E => E.FName)
            //    .HasMaxLength(50);

            //modelBuilder.Entity<Employee>().Property(E => E.LName)
            //    .HasMaxLength(50);

            //modelBuilder.Entity<Employee>().Property(E => E.MName)
            //    .HasMaxLength(2)
            //    .IsFixedLength()
            //    .IsRequired(false);

            //modelBuilder.Entity<Employee>().Property(E=>E.Salary)
            //    .HasColumnType("money")
            //    .HasColumnName("OrderDeposite");
            //}
            #endregion

            #region  New Style for Fluent API

            modelBuilder.Entity<Employee>(EntityBuilder =>
            {
                EntityBuilder.Ignore(E => E.EId)
                   .HasKey(E => E.EId);

                EntityBuilder.Property(E => E.FName)
                    .HasMaxLength(50);

                EntityBuilder.Property(E => E.LName)
                    .HasMaxLength(50);

                EntityBuilder.Property(E => E.MName)
                    .HasMaxLength(2)
                    .IsFixedLength()
                    .IsRequired(false);

                EntityBuilder.Property(E => E.Salary)
                    .HasColumnType("money")
                    .HasColumnName("OrderDeposite");

            });
            ///4. Configuration Class
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
            


            base.OnModelCreating(modelBuilder);
        }

      
#endregion

public virtual DbSet<Employee> Employees { get; set; }
    }
}
