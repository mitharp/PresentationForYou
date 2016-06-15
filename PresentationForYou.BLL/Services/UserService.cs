using PresentationForYou.BLL.DTO;
using PresentationForYou.BLL.Interfaces;
using PresentationForYou.DAL.Entities;
using PresentationForYou.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace PresentationForYou.BLL.Services
{
    public class UserService : IService<UserDTO>
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Add(UserDTO user)
        {
            Database.Users.Create(new User
            {
                Id = user.Id,
                BirthDay = user.BirthDay,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone,
                RegistrationDateTime = user.RegistrationDateTime,
                Role = user.Role
            });
            Database.Save();
        }

        public void Dispose() { }

        public void Edit(UserDTO user)
        {
            Database.Users.Update(new User
            {
                Id = user.Id,
                BirthDay = user.BirthDay,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone,
                RegistrationDateTime = user.RegistrationDateTime,
                Role = user.Role
            });
            Database.Save();
        }

        public void Remove(int id)
        {
            Database.Users.Delete(id);
            Database.Save();
        }

        public UserDTO Get(int? id)
        {
            if (id == null)
                throw new Exception("ERROR");
            var user = Database.Users.Get(id.Value);
            if (user == null)
                throw new Exception("ERROR");

            return new UserDTO
            {
                Id = user.Id,
                BirthDay = user.BirthDay,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone,
                RegistrationDateTime = user.RegistrationDateTime,
                Role = user.Role
            };
        }

        public IEnumerable<UserDTO> GetAll()
        {
            List<UserDTO> usersDTO = new List<UserDTO>();
            var users = Database.Users.GetAll();
            foreach (var user in users)
                usersDTO.Add(new UserDTO
                {
                    Id = user.Id,
                    BirthDay = user.BirthDay,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Phone = user.Phone,
                    RegistrationDateTime = user.RegistrationDateTime,
                    Role = user.Role
                });
            return usersDTO;
        }
    }
}