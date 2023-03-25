namespace task1.Models
{
    public class CourseList
    {
        public static List<Courses> Courses = new List<Courses>()
            {
             new Courses() {id = 1 , name ="C" , duration= 60 , description ="intro to .net and c# Basics" },
             new Courses() {id = 2 , name ="SQL" , duration=50 , description ="Structure Query Language" },
             new Courses() {id = 3 , name ="Asp.net" , duration= 36 , description ="Server Side Programming" },
             new Courses() {id = 4 , name ="MVC" , duration= 30 , description ="Server Side Programming" },
            };
    }
}
