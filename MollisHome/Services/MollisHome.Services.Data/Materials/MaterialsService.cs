namespace MollisHome.Services.Data.Materials
{
    using AutoMapper;

    using MollisHome.Data;
    using MollisHome.Data.Models;
    using MollisHome.Services.Data.Base;
    using MollisHome.Services.DTOs.Materials;

    public class MaterialsService : BaseService<Material, MaterialDTO>, IMaterialsService
    {
        //------------- CONSTRUCTORS --------------
        public MaterialsService(IMapper mapper, ApplicationDbContext dbContext) : base(mapper, dbContext)
        {

        }

        //--------------- METHODS -----------------

    }
}
