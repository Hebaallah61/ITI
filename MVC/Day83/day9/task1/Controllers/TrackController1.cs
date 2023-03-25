using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task1.Models;
using task1.RepoServices;

namespace task1.Controllers
{
    public class TrackController1 : Controller
    {
        public ICourse CourseRepo { get; }
        public ITrack TrackRepo { get; }
        public ITrainee TraineeRepo { get; }

        public TrackController1(ICourse CRepo, ITrainee TRepo, ITrack KRepo)
        {
            CourseRepo = CRepo;
            TraineeRepo = TRepo;
            TrackRepo = KRepo;

        }
        // GET: TrackController1
        public ActionResult Index()
        {
            return View(TrackRepo.GetAll());
        }

        // GET: TrackController1/Details/5
        public ActionResult Details(int id)
        {
            return View(TrackRepo.GetDetails(id));
        }

        // GET: TrackController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrackController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Track track)
        {
            try
            {
                TrackRepo.Insert(track);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TrackController1/Edit/5
        public ActionResult Edit(int id)
        {
            
            return View(TrackRepo.GetDetails(id));
        }

        // POST: TrackController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Track track)
        {
            try
            {
                TrackRepo.UpdateTrack(id, track);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TrackController1/Delete/5
        public ActionResult Delete(int id)
        {
            
            return View(TrackRepo.GetDetails(id));
        }

        // POST: TrackController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                TrackRepo.DeleteTrack(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
