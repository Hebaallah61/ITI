using SharedModel;

namespace task1.Services
{
    public interface ITrainee
    {
        Task<IEnumerable<Trainee>> GetAllTrainee();
        Task<Trainee> GetTraineeDetails(int traineeid);
        Task AddTrainee(Trainee trainee);
        Task UpdateTrainee(int id, Trainee trainee);
        Task DeleteTrainee(int traineeid);
    }
}
