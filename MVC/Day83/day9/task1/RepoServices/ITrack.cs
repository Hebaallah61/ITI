using System.Diagnostics;
using task1.Models;

namespace task1.RepoServices
{
    public interface ITrack
    {
        public List<Track> GetAll();
        public Track GetDetails(int id);
        public void Insert(Track t);
        public void UpdateTrack(int id, Track t);
        public void DeleteTrack(int id);
    }
}
