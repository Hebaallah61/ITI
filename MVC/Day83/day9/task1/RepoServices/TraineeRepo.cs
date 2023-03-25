using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using task1.Areas.Identity.Data;
using task1.Models;

namespace task1.RepoServices
{
    public class TraineeRepo : ITrainee
    {
        public MeDBContext Context { get; }

        
        public TraineeRepo(MeDBContext context)
        {
            Context = context;
        }

        public void DeleteTrainee(int id)
        {
            Context.Remove(Context.Trainees.Find(id));
            Context.SaveChanges();
        }

        public List<Trainee> GetAll()
        {
            return Context.Trainees.Include(b => b.Track).Include(b=>b.Course).ToList();
        }

        public Trainee GetDetails(int id)
        {
            return Context.Trainees.Include(b => b.Track).Include(b => b.Course).FirstOrDefault(b => b.ID == id);
        }

        public void Insert(Trainee t)
        {
            Context.Trainees.Add(t);
            Context.SaveChanges();
        }

        public void UpdateTrainee(int id, Trainee t)
        {
            Trainee trainee = Context.Trainees.Include(b => b.Track).Include(b => b.Course).FirstOrDefault(b => b.ID == id);

            trainee.email = t.email;
            trainee.TID = t.TID;
            trainee.Track = t.Track;
            trainee.CID = t.CID;
            trainee.Birthdate= t.Birthdate;
            trainee.Course = t.Course;
            trainee.MobileNo = t.MobileNo;
            trainee.Gender = t.Gender;
            trainee.Name= t.Name;
            trainee.ID = t.ID;
            

            Context.SaveChanges();
        }
    }
}
