using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using task1.Data;
using task1.Models;

namespace task1.Controllers
{
    public class Order_Controller : Controller
    {
        private task1Context db = new task1Context();

        // GET: Order_
        public ActionResult Index()
        {
            ViewBag.CustOrders = db.Client_.ToList();
            var order_ = db.Order_.Include(o => o.Client_);
            return View(order_.ToList());
        }
        [MyCustomExceptionHandler]
        [HttpPost]
        
        public ActionResult Index(Client_ c)
        {
            ViewBag.CustOrders = db.Client_.ToList();

            var order_ = db.Order_.Include(o => o.Client_).Where(o=>o.CustID==c.CustID).ToList();
            if(order_ == null || order_.Count == 0)
            {
                throw new Exception();//Run Without Debuging
            }
            return View(order_.ToList());
        }



        // GET: Order_/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_ order_ = db.Order_.Find(id);
            if (order_ == null)
            {
                return HttpNotFound();
            }
            return View(order_);
        }

        // GET: Order_/Create
        public ActionResult Create()
        {
            ViewBag.CustID = new SelectList(db.Client_, "CustID", "Name");
            return View();
        }

        // POST: Order_/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TotalPrice,Date,CustID")] Order_ order_)
        {
            if (ModelState.IsValid)
            {
                db.Order_.Add(order_);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustID = new SelectList(db.Client_, "CustID", "Name", order_.CustID);
            return View(order_);
        }

        // GET: Order_/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_ order_ = db.Order_.Find(id);
            if (order_ == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustID = new SelectList(db.Client_, "CustID", "Name", order_.CustID);
            return View(order_);
        }

        // POST: Order_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TotalPrice,Date,CustID")] Order_ order_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order_).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustID = new SelectList(db.Client_, "CustID", "Name", order_.CustID);
            return View(order_);
        }

        // GET: Order_/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_ order_ = db.Order_.Find(id);
            if (order_ == null)
            {
                return HttpNotFound();
            }
            return View(order_);
        }

        // POST: Order_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order_ order_ = db.Order_.Find(id);
            db.Order_.Remove(order_);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
