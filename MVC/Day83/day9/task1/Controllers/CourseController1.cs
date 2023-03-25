using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task1.Models;
using task1.RepoServices;

namespace task1.Controllers
{
    public class CourseController1 : Controller
    {
        public ICourse CourseRepo { get; }
        public ITrack TrackRepo { get; }
        public ITrainee TraineeRepo { get; }

        public CourseController1(ICourse CRepo, ITrainee TRepo,ITrack KRepo)
        {
            CourseRepo = CRepo;
            TraineeRepo = TRepo;
            TrackRepo = KRepo;

        }
        // GET: CourseController1
        public ActionResult Index()
        {
            return View(CourseRepo.GetAll());
        }

        // GET: CourseController1/Details/5
        public ActionResult Details(int id)
        {
            return View(CourseRepo.GetDetails(id));
        }

        // GET: CourseController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            try
            {
                CourseRepo.Insert(course);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController1/Edit/5
        public ActionResult Edit(int id)
        {
            
            return View(CourseRepo.GetDetails(id));
        }

        // POST: CourseController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Course course)
        {
            try
            {
                CourseRepo.UpdateCourse(id, course);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController1/Delete/5
        public ActionResult Delete(int id)
        {
            
            return View(CourseRepo.GetDetails(id));
        }

        // POST: CourseController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                CourseRepo.DeleteCourse(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
