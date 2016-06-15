using System;

namespace PresentationForYou.DAL.Entities
{
    class Request
    {
        public int ID { get; set; }
        public DateTime BeginningDatetime { get; set; }
        public DateTime EndDatetime { get; set; }
        public string ResourceType { get; set; }
        public int ResourceID { get; set; }
        public int UserID { get; set; }
        public bool IsAccepted { get; set; }

        public virtual User User { get; set; }
        public virtual Auditory Auditory { get; set; }
        public virtual Projector Projector { get; set; }
        public virtual Board Board { get; set; }
    }
}
