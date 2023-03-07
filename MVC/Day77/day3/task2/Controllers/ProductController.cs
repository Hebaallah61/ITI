using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using task2.Models;

namespace task2.Controllers
{
    public class ProductController : Controller
    {

        NorthwindEntities context=new NorthwindEntities();  //DB 

        // GET: Product
        public ActionResult Index()
        {
            ViewBag.csupliers = context.Suppliers.ToList();
            return View(context.Products.ToList());
        }
        [HttpPost]
        public ActionResult Index(Product p)
        {
            ViewBag.csupliers = context.Suppliers.ToList();
            return View(context.Products.Where(i=>i.SupplierID==p.SupplierID).ToList());
        }


        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            Product product = context.Products.Find(id);
            ViewBag.dsupliers = context.Suppliers.ToList();
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.psupliers = context.Suppliers.ToList();
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product p)
        {
            try
            {
               
                context.Products.Add(p);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            Product product=context.Products.Find(id);
            ViewBag.supliers=context.Suppliers.ToList();
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Product product = context.Products.Find(id);
                
                product.ProductName = collection["ProductName"];
                product.SupplierID =int.Parse( collection["SupplierID"]);
                product.CategoryID = int.Parse(collection["CategoryID"]);
                product.QuantityPerUnit = collection["QuantityPerUnit"];
                product.UnitPrice = decimal.Parse(collection["UnitPrice"]);
                product.UnitsInStock = short.Parse(collection["UnitsInStock"]);
                product.UnitsOnOrder = short.Parse(collection["UnitsOnOrder"]);
                product.ReorderLevel =short.Parse( collection["ReorderLevel"]);
                product.Discontinued = bool.Parse(collection["Discontinued"]);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Product product = context.Products.Find(id);
                ViewBag.supliers = context.Suppliers.ToList();
                
                context.Products.Remove(product);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                
                return View("Delete");
            }
        }

        //public ActionResult Search(int id)
        //{
        //    ViewBag.csupliers = context.Suppliers.ToList();
        //    return RedirectToAction("Index");
        //}
    }
}
