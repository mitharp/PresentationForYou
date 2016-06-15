using PresentationForYou.BLL.DTO;
using PresentationForYou.BLL.Interfaces;
using System.Collections.Generic;
using System;
using PresentationForYou.DAL.Interfaces;
using PresentationForYou.DAL.Entities;

namespace BudgetApp.BLL.Services
{
    public class SourceService : IService<SourceDTO>
    {
        IUnitOfWork Database { get; set; }
        public SourceService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void Add(SourceDTO source)
        {
            Database.Sources.Create(new Source { Name = source.Name, Description = source.Description });
            Database.Save();
        }
        public void Dispose()
        {
            //
        }
        public void Edit(SourceDTO source)
        {
            Database.Sources.Update(new Source { Id = source.Id, Name = source.Name, Description = source.Description });
            Database.Save();
        }
        public void Remove(int id)
        {
            Database.Sources.Delete(id);
            Database.Save();
        }
        public SourceDTO Get(int? id)
        {
            if (id == null)
                throw new Exception("Не установлено id телефона");
            var source = Database.Sources.Get(id.Value);
            if (source == null)
                throw new Exception("Телефон не найден");
            Mapper.Initialize(item => item.CreateMap<Source, SourceDTO>());
            return Mapper.Map<IEnumerable<Source>, List<SourceDTO>>(source)[0];
            return new SourceDTO { Id}
        }
        public IEnumerable<SourceDTO> GetAll()
        {
            Mapper.Initialize(item => item.CreateMap<Source, SourceDTO>());
            return Mapper.Map<IEnumerable<Source>, List<SourceDTO>>(Database.Sources.GetAll());
        }
    }
}
