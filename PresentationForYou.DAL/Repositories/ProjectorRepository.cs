using PresentationForYou.DAL.EF;
using PresentationForYou.DAL.Entities;
using PresentationForYou.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PresentationForYou.DAL.Repositories
{
    public class ProjectorRepository : IRepository<Projector>
    {
        private PresentationForYouContext db;

        public ProjectorRepository(PresentationForYouContext context)
        {
            db = context;
        }

        public void Create(Projector item)
        {
            db.Projectors.Add(item);
        }

        public void Delete(int id)
        {
            db.Projectors.Remove(Find(a => a.Id == id)?.FirstOrDefault());
        }

        public IEnumerable<Projector> Find(Func<Projector, bool> predicate) => db.Projectors.Where(predicate).ToList();

        public Projector Get(int id) => Find(a => a.Id == id).FirstOrDefault();

        public IEnumerable<Projector> GetAll() => db.Projectors;

        public void Update(Projector item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
