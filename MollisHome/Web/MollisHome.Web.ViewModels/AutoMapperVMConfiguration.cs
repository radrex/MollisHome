namespace MollisHome.Web.ViewModels
{
    using AutoMapper;

    using MollisHome.Services.DTOs.Stock;
    using MollisHome.Services.DTOs.Sizes;
    using MollisHome.Services.DTOs.Colors;
    using MollisHome.Services.DTOs.Genders;
    using MollisHome.Services.DTOs.Products;
    using MollisHome.Services.DTOs.Materials;
    using MollisHome.Services.DTOs.Categories;

    using MollisHome.Web.ViewModels.Products;
    using MollisHome.Web.ViewModels.Categories;

    public class AutoMapperVMConfiguration : Profile
    {
        public AutoMapperVMConfiguration()
        {
            CreateMap<CategoryDTO, CategoryVM>();

            CreateMap<MaterialDTO, ProductMaterialVM>();
            CreateMap<GenderDTO, ProductSexVM>();
            CreateMap<SizeDTO, ProductSizeVM>();
            CreateMap<ColorDTO, ProductColorVM>();

            CreateMap<StockDTO, ProductStockVM>();
            CreateMap<ProductDTO, ProductVM>();
        }
    }
}
