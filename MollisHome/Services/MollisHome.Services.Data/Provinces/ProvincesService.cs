namespace MollisHome.Services.Data.Provinces
{
    using AutoMapper;

    using MollisHome.Data;
    using MollisHome.Data.Models;

    using MollisHome.Services.Data.Base;
    using MollisHome.Services.DTOs.Provinces;

    public class ProvincesService : BaseService<Province, ProvinceDTO>, IProvincesService
    {
        //------------- CONSTRUCTORS --------------
        public ProvincesService(IMapper mapper, ApplicationDbContext dbContext) : base(mapper, dbContext)
        {

        }

        //--------------- METHODS -----------------

    }
}
