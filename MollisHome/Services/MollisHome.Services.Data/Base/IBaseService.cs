namespace MollisHome.Services.Data.Base
{
    using MollisHome.Data.Models;

    using System.Collections.Generic;

    public interface IBaseService<T> where T: BaseModel
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Create(T item);
        void Update(T item);
        void Save(T item);
        void Delete(int id);
    }
}
