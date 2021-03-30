namespace MollisHome.Services.Data.Tests
{
    using Xunit;

    using MollisHome.Services.Data.Products;

    using MollisHome.Services.DTOs.Products;
    using MollisHome.Services.DTOs.Categories;

    using Microsoft.Extensions.DependencyInjection;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Data.Sqlite;
    using MollisHome.Data;
    using Microsoft.EntityFrameworkCore;
    using MollisHome.Data.Models;

    public class BaseServiceTests : IClassFixture<DbFixture>
    {
        //---------------- FIELDS -----------------
        private readonly ServiceProvider serviceProvider;

        //------------- CONSTRUCTORS --------------
        public BaseServiceTests(DbFixture fixture)
        {
            this.serviceProvider = fixture.ServiceProvider;
            this.ProductsService = this.serviceProvider.GetRequiredService<IProductsService>();
        }

        //-------------- PROPERTIES ---------------
        private IProductsService ProductsService { get; }

        //--------------- BASE METHODS -----------------

        //---- HasEntities() ----
        [Fact]
        public void HasEntities_ReturnsTrue()
        {
            Assert.True(ProductsService.HasEntities(), "Method should return TRUE.");
        }

        //---- GetAll() ----
        [Theory]
        [InlineData(3)]
        public void GetAll_ReturnsCorrectNumberOfProducts(int productsCount)
        {
            Assert.Equal($"Products count: {productsCount}", $"Products count: {ProductsService.GetAll().Count()}");
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3 })]
        public void GetAll_ReturnsCorrectProducts(int[] expectedIds)
        {
            IEnumerable<int> productIds = ProductsService.GetAll().Select(x => x.Id);
            Assert.True(expectedIds.SequenceEqual(productIds), $"Method should return categories with ids: {String.Join(", ", expectedIds)}");
        }

        //---- GetById(int id) ----
        [Theory]
        [InlineData(1, "Сидни", 1)]
        [InlineData(2, "Рига", 2)]
        [InlineData(3, "Лима", 3)]
        public void GetById_ReturnsCorrectProduct(int expectedId, string expectedName, int id)
        {
            Assert.Equal($"Product ID: {expectedId}", $"Product ID: {ProductsService.GetById(id).Id}");
            Assert.Equal($"Product Name: {expectedName}", $"Product Name: {ProductsService.GetById(id).Name}");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void GetById_ReturnsNull(int id)
        {
            Assert.Null(ProductsService.GetById(id));
        }

        //---- Create(Product productDTO) ----
        [Fact]
        public async Task CreateProduct_ReturnsCorrectMessage()
        {
            Assert.Equal($"Entity with ID: {4} created.", await ProductsService.CreateAsync(new ProductDTO
            {
                Name = "Лимон",
                ImgUrl = "",
                Description = "Лорем ипсум",
                Category = new CategoryDTO
                {
                    Id = 8,
                }
            }));

            Assert.Equal($"Entity with ID: {5} created.", await ProductsService.CreateAsync(new ProductDTO
            {
                Name = "Портокал",
                ImgUrl = "",
                Description = "Лорем ипсум",
                Category = new CategoryDTO
                {
                    Id = 13,
                }
            }));

            Assert.Equal($"Entity with ID: {6} created.", await ProductsService.CreateAsync(new ProductDTO
            {
                Name = "MEGA PROTECTOR",
                ImgUrl = "",
                Description = "Лорем ипсум",
                Category = new CategoryDTO
                {
                    Id = 10,
                }
            }));

            // Revert db to initial state
            await ProductsService.DeleteAsync(4);
            await ProductsService.DeleteAsync(5);
            await ProductsService.DeleteAsync(6);
        }

        //[Fact]
        //public async Task CreateProduct_ReturnsCorrectExceptionMessage()
        //{
        //    // TODO: I need Sqllite db in order to check the constraints...
        //    Assert.Equal($"Cannot insert duplicate key in Products. The duplicate key is (Сидни)", await ProductsService.CreateAsync(new ProductDTO
        //    {
        //        Name = "Сидни",
        //        ImgUrl = "",
        //        Description = "Volcano cake",
        //        Category = new CategoryDTO
        //        {
        //            Id = 8,
        //        }
        //    }));
        //}


        //TODO: write tests for these methods
        //---- Update(Category category) ----
        //---- Save(Category category) ----
        //---- Delete(int id) ----
    }
}
