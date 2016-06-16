using PresentationForYou.BLL.DTO;
using PresentationForYou.BLL.Interfaces;
using PresentationForYou.DAL.Entities;
using PresentationForYou.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace PresentationForYou.BLL.Services
{
    public class LogService : IService<LogDTO>
    {
        IUnitOfWork Database { get; set; }

        public LogService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Add(LogDTO log)
        {
            Database.Logs.Create(new Log
            {
                Id = log.Id,
                BeginningDatetime = log.BeginningDatetime,
                EndDatetime = log.EndDatetime,
                ResourceId = log.ResourceId,
                ResourceType = log.ResourceType,
                UserId = log.UserId,
                User = log.User
            });
            Database.Save();
        }

        public void Dispose() { }

        public void Edit(LogDTO log)
        {
            Database.Logs.Update(new Log
            {
                Id = log.Id,
                BeginningDatetime = log.BeginningDatetime,
                EndDatetime = log.EndDatetime,
                ResourceId = log.ResourceId,
                ResourceType = log.ResourceType,
                UserId = log.UserId,
                User = log.User
            });
            Database.Save();
        }

        public void Remove(int id)
        {
            Database.Logs.Delete(id);
            Database.Save();
        }

        public LogDTO Get(int? id)
        {
            if (id == null)
                throw new Exception("ERROR");
            var log = Database.Logs.Get(id.Value);
            if (log == null)
                throw new Exception("ERROR");

            return new LogDTO
            {
                Id = log.Id,
                BeginningDatetime = log.BeginningDatetime,
                EndDatetime = log.EndDatetime,
                ResourceId = log.ResourceId,
                ResourceType = log.ResourceType,
                UserId = log.UserId,
                User = log.User
            };
        }

        public IEnumerable<LogDTO> GetAll()
        {
            List<LogDTO> logsDTO = new List<LogDTO>();
            var logs = Database.Logs.GetAll();
            foreach (var log in logs)
                logsDTO.Add(new LogDTO
                {
                    Id = log.Id,
                    BeginningDatetime = log.BeginningDatetime,
                    EndDatetime = log.EndDatetime,
                    ResourceId = log.ResourceId,
                    ResourceType = log.ResourceType,
                    UserId = log.UserId,
                    User = log.User
                });
            return logsDTO;
        }
    }
}