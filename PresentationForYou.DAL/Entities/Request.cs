using System;

namespace PresentationForYou.DAL.Entities
{
    public class Request
    {
        public int Id { get; set; }
        public DateTime BeginningDatetime { get; set; }
        public DateTime EndDatetime { get; set; }
        public string ResourceType { get; set; }
        public int ResourceId { get; set; }
        public int UserId { get; set; }
        public bool IsAccepted { get; set; }

        public User User { get; set; }
        public Auditory Auditory { get; set; }
        public Projector Projector { get; set; }
        public Board Board { get; set; }
    }
}
