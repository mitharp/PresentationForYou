using PresentationForYou.DAL.Entities;
using System;

namespace PresentationForYou.BLL.DTO
{
    public class LogDTO
    {
        public int Id { get; set; }
        public DateTime BeginningDatetime { get; set; }
        public DateTime EndDatetime { get; set; }
        public int ResourceId { get; set; }
        public string ResourceType { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}