using Microsoft.EntityFrameworkCore;
using SharedModel;


namespace task1API.Models
{
    public class DBContext:DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        public virtual DbSet<Trainee> Trainees { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Track>().HasData(
                new Track { Id = 1, Name = "Track A", Description = "Description for Track A" },
                new Track { Id = 2, Name = "Track B", Description = "Description for Track B" },
                new Track { Id = 3, Name = "Track C", Description = "Description for Track C" }
            );

            modelBuilder.Entity<Trainee>().HasData(
                new Trainee { Id = 1, Name = "Trainee 1", gender = Gender.Male, email = "trainee1@example.com", MobileNo = "1234567890", Birthdate = new DateTime(2000, 1, 1), IsGraduated = Graduated.True, TrackId = 1 },
                new Trainee { Id = 2, Name = "Trainee 2", gender = Gender.Female, email = "trainee2@example.com", MobileNo = "2345678901", Birthdate = new DateTime(2001, 1, 1), IsGraduated = Graduated.False, TrackId = 2 },
                new Trainee { Id = 3, Name = "Trainee 3", gender = Gender.Male, email = "trainee3@example.com", MobileNo = "3456789012", Birthdate = new DateTime(2002, 1, 1), IsGraduated = Graduated.True, TrackId = 3 }
            );
        }
    }
}
