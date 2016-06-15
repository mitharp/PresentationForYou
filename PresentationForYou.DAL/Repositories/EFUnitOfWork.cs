using System;
using PresentationForYou.DAL.EF;
using PresentationForYou.DAL.Interfaces;
using PresentationForYou.DAL.Entities;

namespace PresentationForYou.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private PresentationForYouContext db;
        private AccountRepository accountRepository;
        private SourceRepository sourceRepository;
        private TransactionRepository transactionRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new PresentationForYouContext(connectionString);
        }
        public IRepository<Account> Accounts
        {
            get
            {
                if (accountRepository == null)
                    accountRepository = new AccountRepository(db);
                return accountRepository;
            }
        }
        public IRepository<Source> Sources
        {
            get
            {
                if (sourceRepository == null)
                    sourceRepository = new SourceRepository(db);
                return sourceRepository;
            }
        }
        public IRepository<Transaction> Transactions
        {
            get
            {
                //if (transactionRepository == null)
                //    transactionRepository = new TransactionRepository(db);
                //return transactionRepository;
                return transactionRepository = transactionRepository == null ? new TransactionRepository(db) : transactionRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    db.Dispose();
                disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}