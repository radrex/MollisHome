namespace MollisHome.Services.Data
{
    using AutoMapper;

    using MollisHome.Data.Models;
    using MollisHome.Services.DTOs.Categories;

    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Category, CategoryDTO>();
        }
    }
}
