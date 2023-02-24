using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace test.Context
{
    internal class LibraryContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

            => optionsBuilder.UseSqlServer("Data Source =.; Initial Catalog = LibraryDB; Integrated Security = True; Encrypt=false");

        public virtual DbSet<Title> Titles { get; set; }//any data stored in dbset like datatable or list<>
        public virtual DbSet<Branch> Branches { get; set; }

    }
}
