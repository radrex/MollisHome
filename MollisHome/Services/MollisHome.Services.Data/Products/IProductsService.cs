namespace MollisHome.Services.Data.Products
{
    using MollisHome.Data.Models;

    using MollisHome.Services.Data.Base;
    using MollisHome.Services.DTOs.Products;

    using System.Collections.Generic;

    public interface IProductsService : IBaseService<Product, ProductDTO>
    {
        IEnumerable<ProductDTO> GetByCategoryName(string category);
        IEnumerable<ProductDTO> GetNewestProducts(int n);
        IEnumerable<ProductDTO> GetTopSellingProducts(int n);
    }
}
