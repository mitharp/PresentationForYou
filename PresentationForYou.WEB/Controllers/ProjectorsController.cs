using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PresentationForYou.WEB.Models;
using PresentationForYou.BLL.DTO;
using PresentationForYou.BLL.Interfaces;

namespace PresentationForYou.WEB.Controllers
{
    public class ProjectorsController : Controller
    {
        IService<ProjectorDTO> projectorService;
        IEnumerable<Projector> Projectors;
        public ProjectorsController()
        {

        }
        public ProjectorsController(IService<ProjectorDTO> projectorService)
        {
            this.projectorService = projectorService;
            IEnumerable<ProjectorDTO> projector = projectorService.GetAll();
            Projectors = projector.Select(a => new Projector
            {
                Id = a.Id,
                Name = a.Name,
                Resolution = a.Resolution,
                Type = a.Type
            }).ToList();
        }
        // GET: Projectors
        public ActionResult Index()
        {
            return View(Projectors);
        }

        // GET: Projectors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var projectorDTO = projectorService.Get(id);
            if (projectorDTO == null)
            {
                return HttpNotFound();
            }
            return View(new Projector
            {
                Id = projectorDTO.Id,
                Name = projectorDTO.Name,
                Resolution = projectorDTO.Resolution,
                Type = projectorDTO.Type
            });
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
                projectorService.Add(new ProjectorDTO
                {
                    Id = projector.Id,
                    Name = projector.Name,
                    Resolution = projector.Resolution,
                    Type = projector.Type,
                });
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
            var projectorDTO = projectorService.Get(id);
            Projector projector = new Models.Projector
            {
                Id = projectorDTO.Id,
                Name = projectorDTO.Name,
                Resolution = projectorDTO.Resolution,
                Type = projectorDTO.Type,
            };
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
                projectorService.Edit(new ProjectorDTO
                {
                    Id = projector.Id,
                    Name = projector.Name,
                    Resolution = projector.Resolution,
                    Type = projector.Type,
                });
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
            ProjectorDTO projectorDTO = projectorService.Get(id);
            Projector projector = new Projector()
            {
                Id = projectorDTO.Id,
                Name = projectorDTO.Name,
                Resolution = projectorDTO.Resolution,
                Type = projectorDTO.Type,
            };
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
            projectorService.Remove(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                projectorService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}