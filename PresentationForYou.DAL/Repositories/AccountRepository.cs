using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using PresentationForYou.DAL.EF;
using PresentationForYou.DAL.Entities;
using PresentationForYou.DAL.Interfaces;

namespace PresentationForYou.DAL.Repositories
{
    public class AccountRepository : IRepository<Account>
    {
        private PresentationForYouContext db;
        public AccountRepository(PresentationForYouContext context)
        {
            db = context;
        }

        public void Create(Account item)
        {
            db.Accounts.Add(item);
        }

        public void Delete(int id)
        {
            db.Accounts.Remove(Find(a => a.Id == id)?.FirstOrDefault());
        }

        public IEnumerable<Account> Find(Func<Account, bool> predicate) => db.Accounts.Where(predicate).ToList();

        public IEnumerable<Account> Get(int id) => Find(a => a.Id == id);

        public IEnumerable<Account> GetAll() => db.Accounts;

        public void Update(Account item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
