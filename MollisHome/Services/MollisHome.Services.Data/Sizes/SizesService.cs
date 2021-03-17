namespace MollisHome.Services.Data.Sizes
{
    using AutoMapper;

    using MollisHome.Data;
    using MollisHome.Data.Models;
    using MollisHome.Services.Data.Base;
    using MollisHome.Services.DTOs.Sizes;

    public class SizesService : BaseService<Size, SizeDTO>, ISizesService
    {
        //------------- CONSTRUCTORS --------------
        public SizesService(IMapper mapper, ApplicationDbContext dbContext) : base(mapper, dbContext)
        {

        }

        //--------------- METHODS -----------------

    }
}
