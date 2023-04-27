using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SharedModel
{
    public class LattieData
    {
       
        
            // Create some tracks

            public static List<Track> Tracks = new List<Track>
            {
                new Track {Id=1, Name = "C# Development", Description = "Learn C# programming language" },
                new Track {Id=2, Name = "Web Development", Description = "Learn web development with HTML, CSS and JavaScript"},
                new Track {Id=3, Name = "Data Science", Description = "Learn data science with Python and R" }
            };

            // Create some trainees
            public static List<Trainee> Trainees = new List<Trainee>()
            {

                    new Trainee {Id=1, Name = "John Smith", gender = Gender.Male, email = "john.smith@example.com", MobileNo = "1234567890", Birthdate = new DateTime(1990, 5, 15), IsGraduated = Graduated.True, TrackId = 1 },
                    new Trainee {Id=2, Name = "Sarah Johnson", gender = Gender.Female, email = "sarah.johnson@example.com", MobileNo = "2345678901", Birthdate = new DateTime(1995, 7, 20), IsGraduated = Graduated.False, TrackId = 2 },
                    new Trainee {Id=3, Name = "Mike Williams", gender = Gender.Male, email = "mike.williams@example.com", MobileNo = "3456789012", Birthdate = new DateTime(2000, 10, 1), IsGraduated = Graduated.False, TrackId = 2},
                    new Trainee {Id=4, Name = "Emily Brown", gender = Gender.Female, email = "emily.brown@example.com", MobileNo = "4567890123", Birthdate = new DateTime(1998, 12, 5), IsGraduated = Graduated.True, TrackId = 3 }


            };

    }    
}


