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
                    Quantity = product.Quantity,
                    Price = product.Price,
                    CategoryId = product.CategoryId,
                });
                await dbContext.SaveChangesAsync(); // Do it on each step to preserve insertion order. :(

                await this.SeedMappingTable<ProductSex>(dbContext, product.Id, product.SexIds);
                await this.SeedMappingTable<ProductSize>(dbContext, product.Id, product.SizeIds);
                await this.SeedMappingTable<ProductMaterial>(dbContext, product.Id, product.MaterialIds);
                await this.SeedMappingTable<ProductColor>(dbContext, product.Id, product.ColorIds);
            }
        }

        private async Task SeedMappingTable<TEntity>(ApplicationDbContext dbContext, int productId, int[] ids) where TEntity : new()
        {
            foreach (int id in ids)
            {
                TEntity entity = (TEntity)Activator.CreateInstance(typeof(TEntity));
                entity.GetType().GetProperty("ProductId").SetValue(entity, productId);
                switch (typeof(TEntity).Name) //TODO: Find a way to make this section generic with dbContext...
                {
                    case "ProductSex":
                        entity.GetType().GetProperty("SexId").SetValue(entity, id);
                        await dbContext.ProductSexes.AddAsync(entity as ProductSex);
                        break;

                    case "ProductSize":
                        entity.GetType().GetProperty("SizeId").SetValue(entity, id);
                        await dbContext.ProductSizes.AddAsync(entity as ProductSize);
                        break;

                    case "ProductMaterial":
                        entity.GetType().GetProperty("MaterialId").SetValue(entity, id);
                        await dbContext.ProductMaterials.AddAsync(entity as ProductMaterial);
                        break;

                    case "ProductColor":
                        entity.GetType().GetProperty("ColorId").SetValue(entity, id);
                        await dbContext.ProductColors.AddAsync(entity as ProductColor);
                        break;

                    default:
                        break;
                }
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
