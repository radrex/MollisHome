namespace MollisHome.Services.Data.Colors
{
    using AutoMapper;

    using MollisHome.Data;
    using MollisHome.Data.Models;

    using MollisHome.Services.Data.Base;
    using MollisHome.Services.DTOs.Colors;

    public class ColorsService : BaseService<Color, ColorDTO>, IColorsService
    {
        //------------- CONSTRUCTORS --------------
        public ColorsService(IMapper mapper, ApplicationDbContext dbContext) : base(mapper, dbContext)
        {

        }

        //--------------- METHODS -----------------

    }
}
