using Microsoft.EntityFrameworkCore;

namespace task1.Models
{
    public class MeDBContext:DbContext
    {
        public MeDBContext(DbContextOptions options):base(options)
        {
            
        }
        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
    }
}
