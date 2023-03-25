using task1.Models;

namespace task1.RepoServices
{
    public interface ITrainee
    {
        public List<Trainee> GetAll();
        public Trainee GetDetails(int id);
        public void Insert(Trainee t);
        public void UpdateTrainee(int id, Trainee t);
        public void DeleteTrainee(int id);
    }
}
