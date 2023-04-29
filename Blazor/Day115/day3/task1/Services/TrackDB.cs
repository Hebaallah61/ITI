using SharedModel;
using System.Net.Http.Json;
using task1.Pages.Trainee;

namespace task1.Services
{
    public class TrackDB : ITrack
    {
        public HttpClient HttpClient { get; }
        public TrackDB(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }
        public async Task AddTrack(Track track)
        {
            await HttpClient.PostAsJsonAsync<Track>("/api/Tracks/", track);
        }

        public async Task DeleteTrack(int trackid)
        {
            await HttpClient.DeleteAsync("/api/Tracks/" + trackid);
        }

        public async Task<IEnumerable<Track>> GetAllTrack()
        {
            return await HttpClient.GetFromJsonAsync<IEnumerable<Track>>("/api/Tracks");
        }

        public async Task<Track> GetTrackDetails(int trackid)
        {
            return await HttpClient.GetFromJsonAsync<Track>("/api/Tracks/" + trackid);
        }

        public async Task UpdateTrack(int id, Track track)
        {
            await HttpClient.PutAsJsonAsync("/api/Tracks/" + id, track);
        }
    }
}
