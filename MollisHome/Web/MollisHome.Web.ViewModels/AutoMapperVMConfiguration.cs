namespace MollisHome.Web.ViewModels
{
    using AutoMapper;

    using MollisHome.Services.DTOs.Categories;
    using MollisHome.Web.ViewModels.Categories;

    public class AutoMapperVMConfiguration : Profile
    {
        public AutoMapperVMConfiguration()
        {
            CreateMap<CategoryDTO, CategoryVM>();
        }
    }
}
