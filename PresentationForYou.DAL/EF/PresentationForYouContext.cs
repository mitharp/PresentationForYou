using System.Data.Entity;
using PresentationForYou.DAL.Entities;

namespace PresentationForYou.DAL.EF
{
    public class PresentationForYouContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Source> Sources { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public PresentationForYouContext()
        {

        }
        public PresentationForYouContext(string connectionString) : base(connectionString)
        {
        }
    }
}
