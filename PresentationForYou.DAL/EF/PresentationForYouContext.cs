using System.Data.Entity;
using PresentationForYou.DAL.Entities;

namespace PresentationForYou.DAL.EF
{
    public class PresentationForYouContext : DbContext
    {
        public DbSet<Auditory> Auditories { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Projector> Projectors { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<User> Users { get; set; }


        public PresentationForYouContext()
        {

        }
        public PresentationForYouContext(string connectionString) : base(connectionString)
        {
        }
    }
}
