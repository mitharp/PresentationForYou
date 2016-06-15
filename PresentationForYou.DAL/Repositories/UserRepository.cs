using PresentationForYou.DAL.EF;
using PresentationForYou.DAL.Entities;
using PresentationForYou.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationForYou.DAL.Repositories
{
    class UserRepository : IRepository<User>
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
            db.Users.Remove(Find(a => a.ID == id)?.FirstOrDefault());
        }

        public IEnumerable<User> Find(Func<User, bool> predicate) => db.Users.Where(predicate).ToList();

        public IEnumerable<User> Get(int id) => Find(a => a.Id == id);

        public IEnumerable<User> GetAll() => db.Users;

        public void Update(User item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
