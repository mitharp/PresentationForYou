using System;
using PresentationForYou.DAL.Entities;

namespace PresentationForYou.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Account> Accounts { get; }
        IRepository<Source> Sources { get; }
        IRepository<Transaction> Transactions { get; }
        void Save();
    }
}
