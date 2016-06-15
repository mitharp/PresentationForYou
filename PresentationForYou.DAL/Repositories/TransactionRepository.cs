using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using PresentationForYou.DAL.EF;
using PresentationForYou.DAL.Entities;
using PresentationForYou.DAL.Interfaces;

namespace PresentationForYou.DAL.Repositories
{
    public class TransactionRepository : IRepository<Transaction>
    {
        private PresentationForYouContext db;
        public TransactionRepository(PresentationForYouContext context)
        {
            db = context;
        }

        public void Create(Transaction item)
        {
            db.Transactions.Add(item);
        }

        public void Delete(int id)
        {
            db.Transactions.Remove(Find(a => a.Id == id)?.FirstOrDefault());
        }

        public IEnumerable<Transaction> Find(Func<Transaction, bool> predicate) => db.Transactions.Where(predicate).ToList();

        public IEnumerable<Transaction> Get(int id) => Find(a => a.Id == id);

        public IEnumerable<Transaction> GetAll() => db.Transactions.Include(a => a.Source).Include(a => a.Account);

        public void Update(Transaction item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
