using SharedModel;
using System.Net.Http.Json;

namespace task1.Services
{
    public class TraineeDB : ITrainee
    {
        public HttpClient HttpClient { get; }
        public TraineeDB(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }
        public async Task AddTrainee(Trainee trainee)
        {
            await HttpClient.PostAsJsonAsync<Trainee>("/api/Trainees/", trainee);
        }

        public async Task DeleteTrainee(int traineeid)
        {
            await HttpClient.DeleteAsync("/api/Trainees/" + traineeid);
        }

        public async Task<IEnumerable<Trainee>> GetAllTrainee()
        {
            return await HttpClient.GetFromJsonAsync<IEnumerable<Trainee>>("/api/Trainees");
        }

        public async Task<Trainee> GetTraineeDetails(int traineeid)
        {
            return await HttpClient.GetFromJsonAsync<Trainee>("/api/Trainees/" + traineeid);
        }

        public async Task UpdateTrainee(int id, Trainee trainee)
        {
            await HttpClient.PutAsJsonAsync("/api/Trainees/" + id, trainee);
        }
    }
}
