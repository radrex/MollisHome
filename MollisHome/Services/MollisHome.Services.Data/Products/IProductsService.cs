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

        ProductDTO GetByName(string productName);
        IEnumerable<ProductDTO> GetByCategoryName(string category);
        IEnumerable<ProductDTO> GetByColor(int colorId);
        IEnumerable<ProductDTO> GetByColor(string colorName);
        IEnumerable<ProductDTO> GetBySex(int sexId);
        IEnumerable<ProductDTO> GetBySex(string sexName);
        IEnumerable<ProductDTO> GetBySize(int sizeId);
        IEnumerable<ProductDTO> GetBySize(string sizeName);
        IEnumerable<ProductDTO> GetByMaterial(int materialId);
        IEnumerable<ProductDTO> GetByMaterial(string materialName);

        IEnumerable<ProductDTO> GetTopSellingProducts(int n);
        IEnumerable<ProductDTO> GetTopSellingProductsByCategory(int categoryId, int n);
        IEnumerable<ProductDTO> GetTopSellingProductsByCategory(string categoryName, int n);
    }
}
