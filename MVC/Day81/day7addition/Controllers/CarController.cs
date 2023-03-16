using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers;
using WebApplication1.Models;


namespace WebApplication1.Controllers;

public class Car : Controller
{
    
    
    // GET: Car
    public ActionResult Index()
    {
        return View();
    }

    public ActionResult getAllCars()
    {
        List<Models.Car> carLst = CarList.Cars;

        ViewBag.Cars = carLst;

        return View();
    }

    public ActionResult getById(int id)
    {
        ViewBag.selectedCar = CarList.Cars.FirstOrDefault(c => c.Num == id);

        return View();
    }

    public ActionResult EditCar(int id)
    {
        ViewBag.selectedCar = CarList.Cars.FirstOrDefault(c => c.Num == id);

        return View();
    }

    [HttpPost]
    public ActionResult EditCar(int Num, string color, string model, string Manfacture)
    {
        Models.Car? edidtedCar = CarList.Cars.FirstOrDefault(c => c.Num == Num);

        edidtedCar.Num = Num;
        edidtedCar.Color = color;
        edidtedCar.Model = model;
        edidtedCar.Manfacture = Manfacture;

        return RedirectToAction("getAllCars");
    }


    public ActionResult deletecar(int id)
    {
        var deletedCar = CarList.Cars.FirstOrDefault(c => c.Num == id);
        CarList.Cars.Remove(deletedCar);
        return RedirectToAction("getAllCars");

    }



    public ActionResult AddCar()
    {

        return View();
    }
    [HttpPost]
    public ActionResult AddCar(int Num, string color, string model, string Manfacture)
    {
        //Car addCar = new Car() { Num = Num, Color = color, Model = model, Manfacture = Manfacture };
        WebApplication1.Models.Car addCar = new WebApplication1.Models.Car() { Num = Num, Color = color, Model = model, Manfacture = Manfacture };

        CarList.Cars.Add(addCar);
       
        return RedirectToAction("getAllCars");
    }

   

    // GET
    //public IActionResult Index()
    //{
     //   return View();
    //}
}