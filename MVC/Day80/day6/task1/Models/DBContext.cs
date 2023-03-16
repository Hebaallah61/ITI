using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace task1.Models
{
    public class DBContext:DbContext
    {
        public DBContext() : base("myCon")
        {

        }

        public DbSet<Client> Clients { get; set; }
    }
}