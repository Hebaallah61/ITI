using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.Entities;

namespace test.Configrations
{
    
    // 4 ways for Mapping
    // 1. EF Convensions
    // 2. Data Annotations
    // 3. Fluent API


    // 4. Configuration Class 
    // refactoring Fluent API into Seprate class per entity 
    
    internal class EmployeeConfig : IEntityTypeConfiguration<Employee>
        {
            public void Configure(EntityTypeBuilder<Employee> EntityBuilder)
            {
           
                EntityBuilder.Ignore(E=>E.EId)
                   .HasKey(E => E.EId);

                EntityBuilder.Property(E => E.FullName)
                    .HasMaxLength(50);

                EntityBuilder.Property(E => E.FName)
                    .HasMaxLength(50);

                EntityBuilder.Property(E => E.MName)
                    .HasMaxLength(2)
                    .IsFixedLength()
                    .IsRequired(false);

                EntityBuilder.Property(C => C.Salary)
                    .HasColumnType("money")
                    .HasColumnName("OrderDeposite");
            


            
        }
    }
    }

