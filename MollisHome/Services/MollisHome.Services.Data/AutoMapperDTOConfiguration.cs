namespace MollisHome.Services.Data
{
    using AutoMapper;

    using MollisHome.Data.Models;
    using MollisHome.Services.DTOs.Products;
    using MollisHome.Services.DTOs.Categories;

    using System.Linq;

    public class AutoMapperDTOConfiguration : Profile
    {
        public AutoMapperDTOConfiguration()
        {
            CreateMap<Category, CategoryDTO>()
                .ForMember(
                    dest => dest.Categories,
                    opt => opt.MapFrom(src => src.Categories)
                 );

            CreateMap<Sex, ProductSexDTO>();
            CreateMap<Size, ProductSizeDTO>();
            CreateMap<Material, ProductMaterialDTO>();
            CreateMap<Color, ProductColorDTO>();
            CreateMap<Product, ProductDTO>()
                .ForMember(
                    dest => dest.Sexes,
                    opt => opt.MapFrom(src => src.Sexes.Select(x => x.Sex).ToList())
                )
                .ForMember(
                    dest => dest.Sizes,
                    opt => opt.MapFrom(src => src.Sizes.Select(x => x.Size).ToList())
                )
                .ForMember(
                    dest => dest.Materials,
                    opt => opt.MapFrom(src => src.Materials.Select(x => x.Material).ToList())
                )
                .ForMember(
                    dest => dest.Colors,
                    opt => opt.MapFrom(src => src.Colors.Select(x => x.Color).ToList())
                );
        }
    }
}
