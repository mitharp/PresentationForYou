using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using PresentationForYou.DAL.EF;
using PresentationForYou.DAL.Entities;
using PresentationForYou.DAL.Interfaces;
using System.Data.Entity.Migrations;

namespace PresentationForYou.DAL.Repositories
{
    public class SourceRepository : IRepository<Source>
    {
        private PresentationForYouContext db;
        public SourceRepository(PresentationForYouContext context)
        {
            db = context;
        }
        public void Create(Source item)
        {
            db.Sources.Add(item);
        }
        public void Delete(int id)
        {
            db.Sources.Remove(Find(a => a.Id == id)?.FirstOrDefault());
        }
        public IEnumerable<Source> Find(Func<Source, bool> predicate) => db.Sources.Where(predicate).ToList();
        public IEnumerable<Source> Get(int id) => Find(a => a.Id == id);
        public IEnumerable<Source> GetAll() => db.Sources;
        public void Update(Source item)
        {
            db.Sources.AddOrUpdate(item);
        }
    }
}
