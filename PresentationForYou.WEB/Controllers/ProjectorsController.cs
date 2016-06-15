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
    public class ProjectorsController : Controller
    {
        private PresentationForYouWEBContext db = new PresentationForYouWEBContext();

        // GET: Projectors
        public ActionResult Index()
        {
            return View(db.Projectors.ToList());
        }

        // GET: Projectors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projector projector = db.Projectors.Find(id);
            if (projector == null)
            {
                return HttpNotFound();
            }
            return View(projector);
        }

        // GET: Projectors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Projectors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Type,Resolution")] Projector projector)
        {
            if (ModelState.IsValid)
            {
                db.Projectors.Add(projector);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projector);
        }

        // GET: Projectors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projector projector = db.Projectors.Find(id);
            if (projector == null)
            {
                return HttpNotFound();
            }
            return View(projector);
        }

        // POST: Projectors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Type,Resolution")] Projector projector)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projector).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projector);
        }

        // GET: Projectors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projector projector = db.Projectors.Find(id);
            if (projector == null)
            {
                return HttpNotFound();
            }
            return View(projector);
        }

        // POST: Projectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Projector projector = db.Projectors.Find(id);
            db.Projectors.Remove(projector);
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