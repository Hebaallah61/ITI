using Microsoft.Ajax.Utilities;
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
    [RoutePrefix("Heba")]
    public class Client_Controller : Controller
    {
        private task1Context db = new task1Context();

        // GET: Client_
        [Route("")]
        public ActionResult Index()
        {
           
            return View(db.Client_.ToList());
        }


        // GET: Client_/Details/5
        [Route("Detail/{id:int}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client_ client_ = db.Client_.Find(id);
            if (client_ == null)
            {
                return HttpNotFound();
            }
            return View(client_);
        }

        // GET: Client_/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client_/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustID,Name,Gender,email,phoneNum")] Client_ client_)
        {
            if (ModelState.IsValid)
            {
                db.Client_.Add(client_);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(client_);
        }

        // GET: Client_/Edit/5
        [Route("Edit/{id:int}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client_ client_ = db.Client_.Find(id);
            if (client_ == null)
            {
                return HttpNotFound();
            }
            return View(client_);
        }

        // POST: Client_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Edit([Bind(Include = "CustID,Name,Gender,email,phoneNum")] Client_ client_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client_).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client_);
        }

        // GET: Client_/Delete/5
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client_ client_ = db.Client_.Find(id);
            if (client_ == null)
            {
                return HttpNotFound();
            }
            return View(client_);
        }

        // POST: Client_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Delete/{id:int}")]
        public ActionResult DeleteConfirmed(int id)
        {
            Client_ client_ = db.Client_.Find(id);
            db.Client_.Remove(client_);
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
