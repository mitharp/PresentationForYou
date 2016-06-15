using PresentationForYou.DAL.EF;
using PresentationForYou.DAL.Entities;
using PresentationForYou.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace PresentationForYou.DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private PresentationForYouContext db;

        public UserRepository(PresentationForYouContext context)
        {
            db = context;
        }

        public void Create(User item)
        {
            db.Users.Add(item);
        }

        public void Delete(int id)
        {
            db.Users.Remove(Find(a => a.Id == id)?.FirstOrDefault());
        }

        public IEnumerable<User> Find(Func<User, bool> predicate) => db.Users.Where(predicate).ToList();

        public User Get(int id) => Find(a => a.Id == id).FirstOrDefault();

        public IEnumerable<User> GetAll() => db.Users;

        public void Update(User item)
        {
            db.Users.AddOrUpdate(item);
        }
    }
}