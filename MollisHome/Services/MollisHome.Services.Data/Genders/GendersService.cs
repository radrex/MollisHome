namespace MollisHome.Services.Data.Genders
{
    using AutoMapper;

    using MollisHome.Data;
    using MollisHome.Data.Models;
    using MollisHome.Services.Data.Base;
    using MollisHome.Services.DTOs.Genders;

    public class GendersService : BaseService<Gender, GenderDTO>, IGendersService
    {
        //------------- CONSTRUCTORS --------------
        public GendersService(IMapper mapper, ApplicationDbContext dbContext) : base(mapper, dbContext)
        {

        }

        //--------------- METHODS -----------------

    }
}
