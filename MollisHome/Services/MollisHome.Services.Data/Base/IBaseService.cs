namespace MollisHome.Services.Data.Base
{
    using MollisHome.Data.Models;

    using MollisHome.Services.DTOs.Base;

    using System.Threading.Tasks;
    using System.Collections.Generic;

    public interface IBaseService<TModel, TDTO> where TModel : BaseModel
                                                where TDTO : BaseDTO
    {
        bool HasEntities();
        IEnumerable<TDTO> GetAll();
        TDTO GetById(int id);
        Task<string> CreateAsync(TDTO item);
        void Update(TModel item);
        //void Save(TModel item);
        void Delete(int id);
    }
}
