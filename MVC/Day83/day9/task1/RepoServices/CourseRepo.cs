using task1.Areas.Identity.Data;
using task1.Models;

namespace task1.RepoServices
{
    public class CourseRepo : ICourse
    {
        public MeDBContext Context { get; }


        public CourseRepo(MeDBContext context)
        {
            Context = context;
        }
        public void DeleteCourse(int id)
        {
            Context.Remove(Context.Courses.Find(id));
            Context.SaveChanges();
        }

        public List<Course> GetAll()
        {
            return Context.Courses.ToList();
        }

        public Course GetDetails(int id)
        {
            return Context.Courses.Find(id);
        }

        public void Insert(Course t)
        {
            Context.Courses.Add(t);
            Context.SaveChanges();
        }

        public void UpdateCourse(int id, Course t)
        {
            Course course = Context.Courses.Find(id);

            course.Topic=t.Topic;
            course.Trainees=t.Trainees;
            course.ID=id;
            course.Grade=t.Grade;
            


            Context.SaveChanges();
        }
    }
}
