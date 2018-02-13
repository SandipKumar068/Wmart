using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WMart.Models;

namespace WMart.Controllers
{
    public class AttendsController : Controller
    {
        private WMartEntities db = new WMartEntities();

        // GET: Attends
        public ActionResult Index()
        {
            return View(db.Attends.ToList());
        }

        // GET: Attends/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attend attend = db.Attends.Find(id);
            if (attend == null)
            {
                return HttpNotFound();
            }
            return View(attend);
        }

        // GET: Attends/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Attends/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CId,Name,CEmail,CPhone,Status")] Attend attend)
        {
            if (string.IsNullOrEmpty(attend.Name))
            {
                ModelState.AddModelError("Name", "Please enter Name");
            }
            
            if (ModelState.IsValid)
            {
                db.Attends.Add(attend);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
          
                 
            else
            {
                return View();
            }

           
        }

        // GET: Attends/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attend attend = db.Attends.Find(id);
            if (attend == null)
            {
                return HttpNotFound();
            }
            return View(attend);
        }

        // POST: Attends/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CId,Name,CEmail,CPhone,Status")] Attend attend)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attend).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(attend);
        }

        // GET: Attends/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attend attend = db.Attends.Find(id);
            if (attend == null)
            {
                return HttpNotFound();
            }
            return View(attend);
        }

        // POST: Attends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Attend attend = db.Attends.Find(id);
            db.Attends.Remove(attend);
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
