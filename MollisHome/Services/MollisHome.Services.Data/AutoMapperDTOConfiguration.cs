namespace MollisHome.Services.Data
{
    using AutoMapper;

    using MollisHome.Data.Models;
    using MollisHome.Services.DTOs.Categories;

    public class AutoMapperDTOConfiguration : Profile
    {
        public AutoMapperDTOConfiguration()
        {
            //CreateMap<Category, CategoryDTO>();

            CreateMap<Category, CategoryDTO>()
                .ForMember(
                    dest => dest.Categories,
                    opt => opt.MapFrom(src => src.Categories)
                 );
        }
    }
}
