using PresentationForYou.DAL.EF;
using PresentationForYou.DAL.Entities;
using PresentationForYou.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PresentationForYou.DAL.Repositories
{
    public class AuditoryRepository : IRepository<Auditory>
    {
        private PresentationForYouContext db;

        public AuditoryRepository(PresentationForYouContext context)
        {
            db = context;
        }

        public void Create(Auditory item)
        {
            db.Auditories.Add(item);
        }

        public void Delete(int id)
        {
            db.Auditories.Remove(Find(a => a.Id == id)?.FirstOrDefault());
        }

        public IEnumerable<Auditory> Find(Func<Auditory, bool> predicate) => db.Auditories.Where(predicate).ToList();

        public Auditory Get(int id) => Find(a => a.Id == id).FirstOrDefault();

        public IEnumerable<Auditory> GetAll() => db.Auditories;

        public void Update(Auditory item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}