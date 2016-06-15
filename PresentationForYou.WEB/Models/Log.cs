using System;

namespace PresentationForYou.WEB.Models
{
    public class Log
    {
        public int Id { get; set; }
        public DateTime BeginningDatetime { get; set; }
        public DateTime EndDatetime { get; set; }
        public int ResourceId { get; set; }
        public string ResourceType { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
