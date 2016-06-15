using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PresentationForYou.WEB.Models;

namespace PresentationForYou.WEB.Controllers
{
    public class AuditoriesController : Controller
    {
        private PresentationForYouWEBContext db = new PresentationForYouWEBContext();

        // GET: Auditories
        public ActionResult Index()
        {
            return View(db.Auditories.ToList());
        }

        // GET: Auditories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auditory auditory = db.Auditories.Find(id);
            if (auditory == null)
            {
                return HttpNotFound();
            }
            return View(auditory);
        }

        // GET: Auditories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Auditories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Capacity,Address,Description")] Auditory auditory)
        {
            if (ModelState.IsValid)
            {
                db.Auditories.Add(auditory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(auditory);
        }

        // GET: Auditories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auditory auditory = db.Auditories.Find(id);
            if (auditory == null)
            {
                return HttpNotFound();
            }
            return View(auditory);
        }

        // POST: Auditories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Capacity,Address,Description")] Auditory auditory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auditory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(auditory);
        }

        // GET: Auditories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auditory auditory = db.Auditories.Find(id);
            if (auditory == null)
            {
                return HttpNotFound();
            }
            return View(auditory);
        }

        // POST: Auditories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Auditory auditory = db.Auditories.Find(id);
            db.Auditories.Remove(auditory);
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
