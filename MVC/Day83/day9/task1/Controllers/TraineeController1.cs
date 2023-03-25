using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task1.Models;
using task1.RepoServices;

namespace task1.Controllers
{
    public class TraineeController1 : Controller
    {
        public ICourse CourseRepo { get; }
        public ITrack TrackRepo { get; }
        public ITrainee TraineeRepo { get; }

        public TraineeController1(ICourse CRepo, ITrainee TRepo, ITrack KRepo)
        {
            CourseRepo = CRepo;
            TraineeRepo = TRepo;
            TrackRepo = KRepo;

        }
        // GET: TraineeController1
        public ActionResult Index()
        {
            return View(TraineeRepo.GetAll());
        }

        // GET: TraineeController1/Details/5
        public ActionResult Details(int id)
        {
            return View(TraineeRepo.GetDetails(id));
        }

        // GET: TraineeController1/Create
        public ActionResult Create()
        {
            ViewBag.TID = TrackRepo.GetAll();
            ViewBag.CID=CourseRepo.GetAll();
            return View();
        }

        // POST: TraineeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Trainee trainee)
        {
            try
            {
                TraineeRepo.Insert(trainee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TraineeController1/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.TID = TrackRepo.GetAll();
            ViewBag.CID = CourseRepo.GetAll();
            return View(TraineeRepo.GetDetails(id));
        }

        // POST: TraineeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Trainee trainee)
        {
            try
            {
                TraineeRepo.UpdateTrainee(id, trainee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TraineeController1/Delete/5
        public ActionResult Delete(int id)
        {
            
            return View(TraineeRepo.GetDetails(id));
        }

        // POST: TraineeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                TraineeRepo.DeleteTrainee(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
