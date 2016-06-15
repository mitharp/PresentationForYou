using PresentationForYou.BLL.DTO;
using PresentationForYou.BLL.Interfaces;
using PresentationForYou.DAL.Entities;
using PresentationForYou.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace PresentationForYou.BLL.Services
{
    public class AuditoryService : IService<AuditoryDTO>
    {
        IUnitOfWork Database { get; set; }

        public AuditoryService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Add(AuditoryDTO auditory)
        {
            Database.Auditories.Create(new Auditory
            {
                Id = auditory.Id,
                Address = auditory.Address,
                Capacity = auditory.Capacity,
                Description = auditory.Description,
                Name = auditory.Name
            });
            Database.Save();
        }

        public void Dispose() { }

        public void Edit(AuditoryDTO auditory)
        {
            Database.Auditories.Update(new Auditory
            {
                Id = auditory.Id,
                Address = auditory.Address,
                Capacity = auditory.Capacity,
                Description = auditory.Description,
                Name = auditory.Name
            });
            Database.Save();
        }

        public void Remove(int id)
        {
            Database.Auditories.Delete(id);
            Database.Save();
        }

        public AuditoryDTO Get(int? id)
        {
            if (id == null)
                throw new Exception("ERROR");
            var auditory = Database.Auditories.Get(id.Value);
            if (auditory == null)
                throw new Exception("ERROR");

            return new AuditoryDTO
            {
                Id = auditory.Id,
                Address = auditory.Address,
                Capacity = auditory.Capacity,
                Description = auditory.Description,
                Name = auditory.Name
            };
        }

        public IEnumerable<AuditoryDTO> GetAll()
        {
            List<AuditoryDTO> auditoriesDTO = new List<AuditoryDTO>();
            var auditories = Database.Auditories.GetAll();
            foreach (var auditory in auditories)
                auditoriesDTO.Add(new AuditoryDTO
                {
                    Id = auditory.Id,
                    Address = auditory.Address,
                    Capacity = auditory.Capacity,
                    Description = auditory.Description,
                    Name = auditory.Name
                });
            return auditoriesDTO;
        }
    }
}