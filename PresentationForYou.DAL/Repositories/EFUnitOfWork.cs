using System;
using PresentationForYou.DAL.EF;
using PresentationForYou.DAL.Interfaces;
using PresentationForYou.DAL.Entities;

namespace PresentationForYou.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private PresentationForYouContext db;
        private AuditoryRepository auditoryRepository;
        private BoardRepository boardRepository;
        private LogRepository logRepository;
        private ProjectorRepository projectorRepository;
        private RequestRepository requestRepository;
        private UserRepository userRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new PresentationForYouContext(connectionString);
        }

        public IRepository<Auditory> Auditories
        {
            get
            {
                if (auditoryRepository == null)
                    auditoryRepository = new AuditoryRepository(db);
                return auditoryRepository;
            }
        }

        public IRepository<Board> Boards
        {
            get
            {
                if (boardRepository == null)
                    boardRepository = new BoardRepository(db);
                return boardRepository;
            }
        }

        public IRepository<Log> Logs
        {
            get
            {
                if (logRepository == null)
                    logRepository = new LogRepository(db);
                return logRepository;
            }
        }

        public IRepository<Projector> Projectors
        {
            get
            {
                if (projectorRepository == null)
                    projectorRepository = new ProjectorRepository(db);
                return projectorRepository;
            }
        }

        public IRepository<Request> Requests
        {
            get
            {
                if (requestRepository == null)
                    requestRepository = new RequestRepository(db);
                return requestRepository;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
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