namespace MollisHome.Web.ViewModels
{
    using AutoMapper;

    using MollisHome.Services.DTOs.Products;
    using MollisHome.Services.DTOs.Categories;

    using MollisHome.Web.ViewModels.Products;
    using MollisHome.Web.ViewModels.Categories;

    public class AutoMapperVMConfiguration : Profile
    {
        public AutoMapperVMConfiguration()
        {
            CreateMap<CategoryDTO, CategoryVM>();

            CreateMap<ProductMaterialDTO, ProductMaterialVM>();
            CreateMap<ProductSexDTO, ProductSexVM>();
            CreateMap<ProductSizeDTO, ProductSizeVM>();
            CreateMap<ProductColorDTO, ProductColorVM>();

            CreateMap<ProductStockDTO, ProductStockVM>();
            CreateMap<ProductDTO, ProductVM>();
        }
    }
}
