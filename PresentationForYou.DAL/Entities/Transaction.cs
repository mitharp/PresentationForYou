using System;

namespace PresentationForYou.DAL.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public decimal Amount { get; set; }
        public int SourceId { get; set; }
        public Source Source { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}