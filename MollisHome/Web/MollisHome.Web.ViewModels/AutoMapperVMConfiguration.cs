namespace MollisHome.Web.ViewModels
{
    using AutoMapper;

    using MollisHome.Services.DTOs.Categories;
    using MollisHome.Services.DTOs.Products;
    using MollisHome.Web.ViewModels.Categories;
    using MollisHome.Web.ViewModels.Products;

    public class AutoMapperVMConfiguration : Profile
    {
        public AutoMapperVMConfiguration()
        {
            CreateMap<CategoryDTO, CategoryVM>();
            
            CreateMap<ProductSexDTO, ProductSexVM>();
            CreateMap<ProductSizeDTO, ProductSizeVM>();
            CreateMap<ProductMaterialDTO, ProductMaterialVM>();
            CreateMap<ProductColorDTO, ProductColorVM>();
            CreateMap<ProductDTO, ProductVM>();
        }
    }
}
