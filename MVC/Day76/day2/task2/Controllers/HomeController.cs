using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace task2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
       
            [HttpPost]
            public ActionResult Index(FormCollection fc)
            {
                ViewBag.Id = fc["id"];
                ViewBag.Name = fc["name"];
                ViewBag.Image = fc["image"];

                return View("Result");
            }


        //public ActionResult Result(string id, string name, string image)
        //{ 
                
             

        //    return View();
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}