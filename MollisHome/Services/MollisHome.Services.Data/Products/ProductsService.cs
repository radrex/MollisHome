namespace MollisHome.Services.Data.Products
{
    using AutoMapper;

    using MollisHome.Data;
    using MollisHome.Data.Models;

    using MollisHome.Services.Data.Base;
    using MollisHome.Services.DTOs.Products;

    using System.Linq;
    using System.Collections.Generic;

    public class ProductsService : BaseService<Product, ProductDTO>, IProductsService
    {
        //------------- CONSTRUCTORS --------------
        public ProductsService(IMapper mapper, ApplicationDbContext dbContext) : base(mapper, dbContext)
        {

        }

        //--------------- METHODS -----------------
        //---- GET LATEST ----
        public ProductDTO GetLatestProduct()
        {
            return this.mapper.Map<Product, ProductDTO>(this.dbSet.LastOrDefault());
        }
        public IEnumerable<ProductDTO> GetLatestProducts(int n)
        {
            return this.dbSet.OrderByDescending(x => x.Id).Take(n).Select(x => this.mapper.Map<Product, ProductDTO>(x)).ToList();
        }

        //---- GET BY ----
        public ProductDTO GetByName(string productName)
        {
            return this.mapper.Map<Product, ProductDTO>(this.dbSet.FirstOrDefault(x => x.Name == productName));
        }

        public IEnumerable<ProductDTO> GetByCategoryName(string categoryName)
        {
            return this.dbSet.Where(x => x.Category.Name == categoryName).Select(x => this.mapper.Map<Product, ProductDTO>(x)).ToList();
        }

        public IEnumerable<ProductDTO> GetByColor(int colorId)
        {
            return this.dbSet.SelectMany(x => x.Stock).Where(x => x.Color.Id == colorId).Select(x => this.mapper.Map<Product, ProductDTO>(x.Product)).ToList();
        }

        public IEnumerable<ProductDTO> GetByColor(string colorName)
        {
            return this.dbSet.SelectMany(x => x.Stock).Where(x => x.Color.Name == colorName).Select(x => this.mapper.Map<Product, ProductDTO>(x.Product)).ToList();
        }

        public IEnumerable<ProductDTO> GetBySex(int sexId)
        {
            return this.dbSet.SelectMany(x => x.Stock).Where(x => x.Sex.Id == sexId).Select(x => this.mapper.Map<Product, ProductDTO>(x.Product)).ToList();
        }

        public IEnumerable<ProductDTO> GetBySex(string sexName)
        {
            return this.dbSet.SelectMany(x => x.Stock).Where(x => x.Sex.Name == sexName).Select(x => this.mapper.Map<Product, ProductDTO>(x.Product)).ToList();
        }

        public IEnumerable<ProductDTO> GetBySize(int sizeId)
        {
            return this.dbSet.SelectMany(x => x.Stock).Where(x => x.Size.Id == sizeId).Select(x => this.mapper.Map<Product, ProductDTO>(x.Product)).ToList();
        }

        public IEnumerable<ProductDTO> GetBySize(string sizeName)
        {
            return this.dbSet.SelectMany(x => x.Stock).Where(x => x.Size.Name == sizeName).Select(x => this.mapper.Map<Product, ProductDTO>(x.Product)).ToList();
        }

        public IEnumerable<ProductDTO> GetByMaterial(int materialId)
        {
            return this.dbSet.SelectMany(x => x.Materials).Where(x => x.Material.Id == materialId).Select(x => this.mapper.Map<Product, ProductDTO>(x.Product)).ToList();
        }

        public IEnumerable<ProductDTO> GetByMaterial(string materialName)
        {
            return this.dbSet.SelectMany(x => x.Materials).Where(x => x.Material.Name == materialName).Select(x => this.mapper.Map<Product, ProductDTO>(x.Product)).ToList();
        }

        //---- GET TOP ----
        public IEnumerable<ProductDTO> GetTopSellingProducts(int n)
        {
            return this.GetAll().OrderByDescending(x => x.Stock.Sum(y => y.Sold)).Take(n).ToList();
        }

        public IEnumerable<ProductDTO> GetTopSellingProductsByCategory(int categoryId, int n)
        {
            return this.dbSet.Where(x => x.Category.Id == categoryId).OrderByDescending(x => x.Stock.Sum(y => y.Sold)).Take(n).Select(x => this.mapper.Map<Product, ProductDTO>(x)).ToList();
        }

        public IEnumerable<ProductDTO> GetTopSellingProductsByCategory(string categoryName, int n)
        {
            return this.dbSet.Where(x => x.Category.Name == categoryName).OrderByDescending(x => x.Stock.Sum(y => y.Sold)).Take(n).Select(x => this.mapper.Map<Product, ProductDTO>(x)).ToList();
        }
    }
}
