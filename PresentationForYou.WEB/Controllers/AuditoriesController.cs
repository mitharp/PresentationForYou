using System;
using System.Collections.Generic;
using System.Data;
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
    public class AuditoriesController : Controller
    {
        IService<AuditoryDTO> auditoryService;
        IEnumerable<Auditory> Auditories;
        public AuditoriesController(IService<AuditoryDTO> auditoryService)
        {
            this.auditoryService = auditoryService;
            IEnumerable<AuditoryDTO> auditory = auditoryService.GetAll();
            Auditories = auditory.Select(a => new Auditory
            {
                Id = a.Id,
                Address = a.Address,
                Capacity = a.Capacity,
                Description = a.Description,
                Name = a.Name
            }).ToList();
        }
        // GET: Auditories
        public ActionResult Index()
        {
            return View(Auditories);
        }

        // GET: Auditories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var auditoryDTO = auditoryService.Get(id);
            if (auditoryDTO == null)
            {
                return HttpNotFound();
            }
            return View(new Auditory
            {
                Id = auditoryDTO.Id,
                Address = auditoryDTO.Address,
                Capacity = auditoryDTO.Capacity,
                Description = auditoryDTO.Description,
                Name = auditoryDTO.Name
            });
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
                auditoryService.Add(new AuditoryDTO
                {
                    Id = auditory.Id,
                    Address = auditory.Address,
                    Capacity = auditory.Capacity,
                    Description = auditory.Description,
                    Name = auditory.Name
                });
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
            var auditoryDTO = auditoryService.Get(id);
            Auditory auditory = new Auditory
            {
                Id = auditoryDTO.Id,
                Address = auditoryDTO.Address,
                Capacity = auditoryDTO.Capacity,
                Description = auditoryDTO.Description,
                Name = auditoryDTO.Name
            };
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
                auditoryService.Edit(new AuditoryDTO
                {
                    Id = auditory.Id,
                    Address = auditory.Address,
                    Capacity = auditory.Capacity,
                    Description = auditory.Description,
                    Name = auditory.Name
                });
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
            AuditoryDTO auditoryDTO = auditoryService.Get(id);
            Auditory auditory = new Auditory
            {
                Id = auditoryDTO.Id,
                Address = auditoryDTO.Address,
                Capacity = auditoryDTO.Capacity,
                Description = auditoryDTO.Description,
                Name = auditoryDTO.Name
            };
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
            auditoryService.Remove(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                auditoryService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
