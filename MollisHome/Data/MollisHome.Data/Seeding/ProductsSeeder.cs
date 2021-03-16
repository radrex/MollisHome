namespace MollisHome.Data.Seeding
{
    using MollisHome.Data.Models;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class ProductsSeeder : ISeeder
    {
        //---------------- FIELDS -----------------
        private readonly IReadOnlyCollection<Product> products;

        //------------- CONSTRUCTORS --------------
        public ProductsSeeder(List<Product> products)
        {
            this.products = products.AsReadOnly();
        }

        //--------------- METHODS -----------------
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Products.Any())
            {
                return;
            }

            foreach (Product product in this.products)
            {
                await dbContext.Products.AddAsync(new Product
                {
                    Name = product.Name,
                    Description = product.Description,
                    ImgUrl = product.ImgUrl,
                    CategoryId = product.CategoryId,
                });
                await dbContext.SaveChangesAsync(); // Do it on each step to preserve insertion order. :(

                await this.SeedMappingTable<ProductMaterial>(dbContext, product.Id, new int[][] { product.MaterialIds });
                await this.SeedMappingTable<ProductStock>(dbContext, product.Id, new int[][] { product.Quantities, product.Sold, product.Prices, product.GenderIds, product.SizeIds, product.ColorIds });
            }
        }

        private async Task SeedMappingTable<TEntity>(ApplicationDbContext dbContext, int productId, int[][] data) where TEntity : new()
        {
            //TODO: CRIES FOR REFACTORING, linked with seed.json be careful... use multidimentional not jagged... Make generic with dbContext somehow
            for (int i = 0; i < data[0].Length; i++)
            {
                TEntity entity = (TEntity)Activator.CreateInstance(typeof(TEntity));
                entity.GetType().GetProperty("ProductId").SetValue(entity, productId);

                switch (typeof(TEntity).Name)
                {
                    case "ProductMaterial":
                        entity.GetType().GetProperty("MaterialId").SetValue(entity, data[0][i]);
                        await dbContext.ProductMaterials.AddAsync(entity as ProductMaterial);
                        break;

                    case "ProductStock":
                        entity.GetType().GetProperty("Quantity").SetValue(entity, data[0][i]);
                        entity.GetType().GetProperty("Sold").SetValue(entity, data[0 + 1][i]);
                        entity.GetType().GetProperty("Price").SetValue(entity, (decimal)data[0 + 2][i]);
                        entity.GetType().GetProperty("GenderId").SetValue(entity, data[0 + 3][i]);
                        entity.GetType().GetProperty("SizeId").SetValue(entity, data[0 + 4][i]);
                        entity.GetType().GetProperty("ColorId").SetValue(entity, data[0 + 5][i]);
                        await dbContext.ProductStock.AddAsync(entity as ProductStock);
                        break;

                    default:
                        break;
                }
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
