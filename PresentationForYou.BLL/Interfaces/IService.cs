using System.Collections.Generic;

namespace PresentationForYou.BLL.Interfaces
{
    public interface IService<T>
    {
        void Add(T item);
        T Get(int? id);
        IEnumerable<T> GetAll();
        void Edit(T item);
        void Remove(int id);
        void Dispose();
    }
}