using task1.Models;

namespace task1.RepoServices
{
    public interface ICourse
    {
        public List<Course> GetAll();
        public Course GetDetails(int id);
        public void Insert(Course t);
        public void UpdateCourse(int id, Course t);
        public void DeleteCourse(int id);
    }
}
