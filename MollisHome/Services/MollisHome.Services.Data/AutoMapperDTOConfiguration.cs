namespace MollisHome.Services.Data
{
    using AutoMapper;

    using MollisHome.Data.Models;

    using MollisHome.Services.DTOs.Stock;
    using MollisHome.Services.DTOs.Sizes;
    using MollisHome.Services.DTOs.Colors;
    using MollisHome.Services.DTOs.Cities;
    using MollisHome.Services.DTOs.Genders;
    using MollisHome.Services.DTOs.Products;
    using MollisHome.Services.DTOs.Addresses;
    using MollisHome.Services.DTOs.Provinces;
    using MollisHome.Services.DTOs.Materials;
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
                 )
                .ForMember(
                    dest => dest.Products,
                    opt => opt.MapFrom(src => src.Products)
                ).ReverseMap()
                 .ForMember(dest => dest.ParentCategory, opt => opt.Ignore());

            CreateMap<Material, MaterialDTO>().ReverseMap();
            CreateMap<Gender, GenderDTO>().ReverseMap();
            CreateMap<Size, SizeDTO>().ReverseMap();
            CreateMap<Color, ColorDTO>().ReverseMap();
            CreateMap<Province, ProvinceDTO>().ReverseMap();
            CreateMap<City, CityDTO>().ReverseMap();
            CreateMap<Address, AddressDTO>().ReverseMap();

            CreateMap<ProductStock, StockDTO>()
                .ForMember(
                    dest => dest.Product,
                    opt => opt.MapFrom(src => src.Product)
                )
                .ForMember(
                    dest => dest.Gender,
                    opt => opt.MapFrom(src => src.Gender)
                )
                .ForMember(
                    dest => dest.Size,
                    opt => opt.MapFrom(src => src.Size)
                )
                .ForMember(
                    dest => dest.Color,
                    opt => opt.MapFrom(src => src.Color)
                ).ReverseMap();

            CreateMap<Product, ProductDTO>()
                .ForMember(
                    dest => dest.Materials,
                    opt => opt.MapFrom(src => src.Materials.Select(x => x.Material).ToList())
                ).ReverseMap()
                .ForMember(dest => dest.Category, opt => opt.Ignore());
        }
    }
}
