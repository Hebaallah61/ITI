using HotalDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HotalDAL.DBcontext
{
    public class Context:DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public  DbSet<Reservation> Reservations { get; set; }

        public  DbSet<Kitchen> Kitchens { get; set; }

        public  DbSet<Frontend> Frontends { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=HotelManagmentSystem;Integrated Security=True;Encrypt=False");
        }

    }
}
