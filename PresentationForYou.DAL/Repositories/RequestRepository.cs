using PresentationForYou.DAL.EF;
using PresentationForYou.DAL.Entities;
using PresentationForYou.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using System.Linq;

namespace PresentationForYou.DAL.Repositories
{
    public class RequestRepository : IRepository<Request>
    {
        private PresentationForYouContext db;

        public RequestRepository(PresentationForYouContext context)
        {
            db = context;
        }

        public void Create(Request item)
        {
            db.Requests.Add(item);
        }

        public void Delete(int id)
        {
            db.Requests.Remove(Find(a => a.Id == id)?.FirstOrDefault());
        }

        public IEnumerable<Request> Find(Func<Request, bool> predicate) => db.Requests.Where(predicate).ToList();

        public Request Get(int id) => Find(a => a.Id == id).FirstOrDefault();

        public IEnumerable<Request> GetAll() => db.Requests;

        public void Update(Request item)
        {
            db.Requests.AddOrUpdate(item);
        }
    }
}