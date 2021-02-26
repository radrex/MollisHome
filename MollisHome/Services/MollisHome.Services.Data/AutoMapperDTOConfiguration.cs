namespace MollisHome.Services.Data
{
    using AutoMapper;

    using MollisHome.Data.Models;
    using MollisHome.Services.DTOs.Categories;

    public class AutoMapperDTOConfiguration : Profile
    {
        public AutoMapperDTOConfiguration()
        {
            CreateMap<Category, CategoryDTO>();
        }
    }
}
