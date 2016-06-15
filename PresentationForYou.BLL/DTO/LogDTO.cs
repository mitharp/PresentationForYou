using System;

namespace PresentationForYou.BLL.DTO
{
    class Log
    {
        public int Id { get; set; }
        public DateTime BeginningDatetime { get; set; }
        public DateTime EndDatetime { get; set; }
        public int ResourceId { get; set; }
        public string ResourceType { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual Auditory Auditory { get; set; }
        public virtual Projector Projector { get; set; }
        public virtual Board Board { get; set; }
    }
}
