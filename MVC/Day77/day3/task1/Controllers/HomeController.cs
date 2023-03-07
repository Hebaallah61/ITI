using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using task1.Models;

namespace task1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Employee() {
            List<Employee> empLst = EmployeeList.Employees;
            return View(empLst);    
        }

        public ActionResult GetById(int id)
        {
            Employee selectedEmp = EmployeeList.Employees.FirstOrDefault(e => e.Id == id);

            return View(selectedEmp);
        }

        public ActionResult delete(int id)
        {
            var deletedEmp = EmployeeList.Employees.FirstOrDefault(e => e.Id == id);
            EmployeeList.Employees.Remove(deletedEmp);
            return RedirectToAction("Employee");  
        }

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