namespace MollisHome.Services.Data.Cities
{
    using AutoMapper;

    using MollisHome.Data;
    using MollisHome.Data.Models;

    using MollisHome.Services.Data.Base;
    using MollisHome.Services.DTOs.Cities;

    public class CitiesService : BaseService<City, CityDTO>, ICitiesService
    {
        //------------- CONSTRUCTORS --------------
        public CitiesService(IMapper mapper, ApplicationDbContext dbContext) : base(mapper, dbContext)
        {

        }

        //--------------- METHODS -----------------

    }
}
