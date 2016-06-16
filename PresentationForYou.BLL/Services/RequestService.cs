using PresentationForYou.BLL.DTO;
using PresentationForYou.BLL.Interfaces;
using PresentationForYou.DAL.Entities;
using PresentationForYou.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace PresentationForYou.BLL.Services
{
    public class RequestService : IService<RequestDTO>
    {
        IUnitOfWork Database { get; set; }

        public RequestService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Add(RequestDTO request)
        {
            Database.Requests.Create(new Request
            {
                Id = request.Id,
                BeginningDatetime = request.BeginningDatetime,
                EndDatetime = request.EndDatetime,
                ResourceId = request.ResourceId,
                ResourceType = request.ResourceType,
                UserId = request.UserId,
                User = request.User
            });
            Database.Save();
        }

        public void Dispose() { }

        public void Edit(RequestDTO request)
        {
            Database.Requests.Update(new Request
            {
                Id = request.Id,
                BeginningDatetime = request.BeginningDatetime,
                EndDatetime = request.EndDatetime,
                ResourceId = request.ResourceId,
                ResourceType = request.ResourceType,
                UserId = request.UserId,
                User = request.User
            });
            Database.Save();
        }

        public void Remove(int id)
        {
            Database.Requests.Delete(id);
            Database.Save();
        }

        public RequestDTO Get(int? id)
        {
            if (id == null)
                throw new Exception("ERROR");
            var request = Database.Requests.Get(id.Value);
            if (request == null)
                throw new Exception("ERROR");

            return new RequestDTO
            {
                Id = request.Id,
                BeginningDatetime = request.BeginningDatetime,
                EndDatetime = request.EndDatetime,
                ResourceId = request.ResourceId,
                ResourceType = request.ResourceType,
                UserId = request.UserId,
                User = request.User
            };
        }

        public IEnumerable<RequestDTO> GetAll()
        {
            List<RequestDTO> requestsDTO = new List<RequestDTO>();
            var requests = Database.Requests.GetAll();
            foreach (var request in requests)
                requestsDTO.Add(new RequestDTO
                {
                    Id = request.Id,
                    BeginningDatetime = request.BeginningDatetime,
                    EndDatetime = request.EndDatetime,
                    ResourceId = request.ResourceId,
                    ResourceType = request.ResourceType,
                    UserId = request.UserId,
                    User = request.User
                });
            return requestsDTO;
        }
    }
}