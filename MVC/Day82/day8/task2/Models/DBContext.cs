using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace task2.Models
{
    public class DBContext:DbContext
    {
        public DBContext(DbContextOptions<DBContext> option) : base(option)
        {
            

        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        
    }
}
