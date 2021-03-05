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

            CreateMap<Material, ProductMaterialDTO>();
            CreateMap<Sex, ProductSexDTO>();
            CreateMap<Size, ProductSizeDTO>();
            CreateMap<Color, ProductColorDTO>();

            CreateMap<ProductStock, ProductStockDTO>()
                .ForMember(
                    dest => dest.Sex,
                    opt => opt.MapFrom(src => src.Sex)
                )
                .ForMember(
                    dest => dest.Size,
                    opt => opt.MapFrom(src => src.Size)
                )
                .ForMember(
                    dest => dest.Color,
                    opt => opt.MapFrom(src => src.Color)
                );

            CreateMap<Product, ProductDTO>()
                .ForMember(
                    dest => dest.Materials,
                    opt => opt.MapFrom(src => src.Materials.Select(x => x.Material).ToList())
                );
        }
    }
}
