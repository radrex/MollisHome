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
        bool Exists(int id);
        int Count();
        IEnumerable<TDTO> GetAll(int? take = null, int skip = 0);
        TDTO GetById(int id);
        Task<string> CreateAsync(TDTO item);
        Task<string> EditAsync(TDTO item);
        Task<string> DeleteAsync(int id);
    }
}
