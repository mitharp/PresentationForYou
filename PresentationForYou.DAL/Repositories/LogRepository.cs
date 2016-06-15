using PresentationForYou.DAL.EF;
using PresentationForYou.DAL.Entities;
using PresentationForYou.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PresentationForYou.DAL.Repositories
{
    public class LogRepository : IRepository<Log>
    {
        private PresentationForYouContext db;

        public LogRepository(PresentationForYouContext context)
        {
            db = context;
        }

        public void Create(Log item)
        {
            db.Logs.Add(item);
        }

        public void Delete(int id)
        {
            db.Logs.Remove(Find(a => a.Id == id)?.FirstOrDefault());
        }

        public IEnumerable<Log> Find(Func<Log, bool> predicate) => db.Logs.Where(predicate).ToList();

        public IEnumerable<Log> Get(int id) => Find(a => a.Id == id);

        public IEnumerable<Log> GetAll() => db.Logs;

        public void Update(Log item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
