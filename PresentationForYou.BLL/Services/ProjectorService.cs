using PresentationForYou.BLL.DTO;
using PresentationForYou.BLL.Interfaces;
using PresentationForYou.DAL.Entities;
using PresentationForYou.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace PresentationForYou.BLL.Services
{
    public class ProjectorService : IService<ProjectorDTO>
    {
        IUnitOfWork Database { get; set; }

        public ProjectorService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Add(ProjectorDTO projector)
        {
            Database.Projectors.Create(new Projector
            {
                Id = projector.Id,
                Name = projector.Name,
                Resolution = projector.Resolution,
                Type = projector.Type
            });
            Database.Save();
        }

        public void Dispose() { }

        public void Edit(ProjectorDTO projector)
        {
            Database.Projectors.Update(new Projector
            {
                Id = projector.Id,
                Name = projector.Name,
                Resolution = projector.Resolution,
                Type = projector.Type
            });
            Database.Save();
        }

        public void Remove(int id)
        {
            Database.Projectors.Delete(id);
            Database.Save();
        }

        public ProjectorDTO Get(int? id)
        {
            if (id == null)
                throw new Exception("ERROR");
            var projector = Database.Projectors.Get(id.Value);
            if (projector == null)
                throw new Exception("ERROR");

            return new ProjectorDTO
            {
                Id = projector.Id,
                Name = projector.Name,
                Resolution = projector.Resolution,
                Type = projector.Type
            };
        }

        public IEnumerable<ProjectorDTO> GetAll()
        {
            List<ProjectorDTO> projectorsDTO = new List<ProjectorDTO>();
            var projectors = Database.Projectors.GetAll();
            foreach (var projector in projectors)
                projectorsDTO.Add(new ProjectorDTO
                {
                    Id = projector.Id,
                    Name = projector.Name,
                    Resolution = projector.Resolution,
                    Type = projector.Type
                });
            return projectorsDTO;
        }
    }
}