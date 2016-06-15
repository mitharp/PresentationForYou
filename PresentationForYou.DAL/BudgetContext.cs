using System.Data.Entity;
using BudgetApp.DAL.Entities;

namespace BudgetApp.DAL.EF
{
    public class BudgetContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Source> Sources { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public BudgetContext()
        {

        }
        public BudgetContext(string connectionString) : base(connectionString)
        {
        }
    }
}
