using PresentationForYou.DAL.Entities;
using System;

namespace BudgetApp.BLL.DTO
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public AccountDTO Account { get; set; }
        public decimal Amount { get; set; }
        public int SourceId { get; set; }
        public SourceDTO Source { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public static explicit operator Transaction(TransactionDTO transaction)
        {
            return new Transaction
            {
                AccountId = transaction.AccountId,
                Amount = transaction.Amount,
                Date = transaction.Date,
                SourceId = transaction.SourceId,
                Description = transaction.Description
            };
        }
    }
}