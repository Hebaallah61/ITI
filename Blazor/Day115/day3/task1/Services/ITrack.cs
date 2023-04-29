using SharedModel;

namespace task1.Services
{
    public interface ITrack
    {
        Task<IEnumerable<Track>> GetAllTrack();
        Task<Track> GetTrackDetails(int trackid);
        Task AddTrack(Track track);
        Task UpdateTrack(int id,Track track);
        Task DeleteTrack(int trackid);

    }
}
