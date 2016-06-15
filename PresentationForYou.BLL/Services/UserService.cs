﻿using PresentationForYou.BLL.DTO;
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
        public void Add(UserDTO source)
        {
            Database.Users.Create(new User { Name = source.Name, Description = source.Description });
            Database.Save();
        }
        public void Dispose()
        {
            //
        }
        public void Edit(UserDTO source)
        {
            Database.Users.Update(new User { Id = source.Id, Name = source.Name, Description = source.Description });
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
                throw new Exception("Не установлено id телефона");
            var source = Database.Users.Get(id.Value);
            if (source == null)
                throw new Exception("Телефон не найден");
            Mapper.Initialize(item => item.CreateMap<User, UserDTO>());
            return Mapper.Map<IEnumerable<User>, List<UserDTO>>(source)[0];
            return new UserDTO { Id = source}
        }
        public IEnumerable<UserDTO> GetAll()
        {
            Mapper.Initialize(item => item.CreateMap<User, UserDTO>());
            return Mapper.Map<IEnumerable<User>, List<UserDTO>>(Database.Users.GetAll());
        }
    }
}