using System;
using PresentationForYou.DAL.Entities;

namespace PresentationForYou.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Auditory> Auditories { get; }
        IRepository<Board> Boards { get; }
        IRepository<Log> Logs { get; }
        IRepository<Projector> Projectors { get; }
        IRepository<Request> Requests { get; }
        IRepository<User> Users { get; }

        void Save();
    }
}