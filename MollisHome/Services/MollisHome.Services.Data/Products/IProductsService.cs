namespace MollisHome.Services.Data.Products
{
    using MollisHome.Data.Models;

    using MollisHome.Services.Data.Base;
    using MollisHome.Services.DTOs.Products;

    using System.Collections.Generic;

    public interface IProductsService : IBaseService<Product, ProductDTO>
    {
        ProductDTO GetLatestProduct();
        IEnumerable<ProductDTO> GetLatestProducts(int n);
        IEnumerable<ProductDTO> GetByCategoryName(string category);
        IEnumerable<ProductDTO> GetTopSellingProducts(int n);
    }
}
