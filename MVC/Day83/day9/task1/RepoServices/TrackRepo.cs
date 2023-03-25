using System.Diagnostics;
using task1.Areas.Identity.Data;
using task1.Models;

namespace task1.RepoServices
{
    public class TrackRepo : ITrack
    {
        public MeDBContext Context { get; }


        public TrackRepo(MeDBContext context)
        {
            Context = context;
        }
        public void DeleteTrack(int id)
        {
            Context.Remove(Context.Tracks.Find(id));
            Context.SaveChanges();
        }

        public List<Track> GetAll()
        {
            return Context.Tracks.ToList();
        }

        public Track GetDetails(int id)
        {
            return Context.Tracks.Find(id);
        }

        public void Insert(Track t)
        {
            Context.Tracks.Add(t);
            Context.SaveChanges();
        }

        public void UpdateTrack(int id, Track t)
        {
            Track track = Context.Tracks.Find(id);

            track.ID=id;
            track.Name=t.Name;
            track.Description=t.Description;
            track.Trainees=t.Trainees;
            



            Context.SaveChanges();
        }
    }
}
