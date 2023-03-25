using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using task1.Models;

namespace task1.Areas.Identity.Data
{
    public class MeDBContext : IdentityDbContext<UApp>
    {
        public MeDBContext(DbContextOptions<MeDBContext> options) : base(options)
        {

        }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
