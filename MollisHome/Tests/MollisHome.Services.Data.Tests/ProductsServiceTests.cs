namespace MollisHome.Services.Data.Tests
{
    using MollisHome.Data;
    using MollisHome.Data.Seeding;
    using MollisHome.Services.Data.Products;

    using Xunit;

    using Microsoft.Extensions.DependencyInjection;

    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class ProductsServiceTests : IClassFixture<DbFixture>
    {
        //---------------- FIELDS -----------------
        private ServiceProvider serviceProvider;

        //------------- CONSTRUCTORS --------------
        public ProductsServiceTests(DbFixture fixture)
        {
            this.serviceProvider = fixture.ServiceProvider;
            ApplicationDbContext dbContext = this.serviceProvider.GetRequiredService<ApplicationDbContext>();
            new DatabaseSeeder().SeedAsync(dbContext, this.serviceProvider).GetAwaiter().GetResult();
            this.productsService = this.serviceProvider.GetRequiredService<IProductsService>();
        }

        //-------------- PROPERTIES ---------------
        private IProductsService productsService { get; }

        //--------------- BASE METHODS -----------------
        #region ProductsServiceBase Tests
        //---- HasEntities() ----
        [Fact]
        public void HasEntities_ReturnsTrue()
        {
            Assert.True(productsService.HasEntities(), "Method should return TRUE.");
        }

        [Fact]
        public void HasEntities_ReturnsFalse()
        {
            //TODO: Delete all entities and assert
            Assert.False(productsService.HasEntities(), "Method should return FALSE.");
        }

        //---- GetAll() ----
        [Theory]
        [InlineData(3)]
        public void GetAll_ReturnsCorrectNumberOfProducts(int productsCount)
        {
            Assert.Equal($"Products count: {productsCount}", $"Products count: {productsService.GetAll().Count()}");
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3 })]
        public void GetAll_ReturnsCorrectProducts(int[] expectedIds)
        {
            IEnumerable<int> productIds = productsService.GetAll().Select(x => x.Id);
            Assert.True(expectedIds.SequenceEqual(productIds), $"Method should return categories with ids: {String.Join(", ", expectedIds)}");
        }

        //---- GetById(int id) ----
        [Theory]
        [InlineData(1, "Сидни", 1)]
        [InlineData(2, "Рига", 2)]
        [InlineData(3, "Лима", 3)]
        public void GetById_ReturnsCorrectProduct(int expectedId, string expectedName, int id)
        {
            Assert.Equal($"Product ID: {expectedId}", $"Product ID: {productsService.GetById(id).Id}");
            Assert.Equal($"Product Name: {expectedName}", $"Product Name: {productsService.GetById(id).Name}");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void GetById_ReturnsNull(int id)
        {
            Assert.Null(productsService.GetById(id));
        }


        //TODO: write tests for these methods
        //---- Create(Category category) ----
        //---- Update(Category category) ----
        //---- Save(Category category) ----
        //---- Delete(int id) ----

        #endregion

        //--------------- CHILD METHODS -----------------
        #region ProductsServiceChild Tests
        //---- GetLatestProduct() ----
        [Fact]
        public void GetLatestProduct_ReturnsCorrectProduct() 
        {
            Assert.Equal("Product Name: Лима", $"Product Name: {productsService.GetLatestProduct().Name}");
            Assert.Equal("Product ID: 3", $"Product ID: {productsService.GetLatestProduct().Id}");
        }

        [Fact]
        public void GetLatestProduct_ReturnsNull()
        {
            //TODO: Return null if no items in db, (first delete them, then assert)
            Assert.Null(productsService.GetLatestProduct());
        }

        //---- GetLatestProducts() ----
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        [InlineData(3, 100)]
        public void GetLatestProducts_ReturnsCorrectNumberOfProducts(int expected, int n)
        {
            Assert.Equal($"Product count: {expected}", $"Product count: {productsService.GetLatestProducts(n).Count()}");
        }

        [Theory]
        [InlineData(new int[] { }, -1)]
        [InlineData(new int[] { 3 }, 1)]
        [InlineData(new int[] { 3, 2 }, 2)]
        [InlineData(new int[] { 3, 2, 1 }, 3)]
        [InlineData(new int[] { 3, 2, 1 }, 100)]
        public void GetLatestProducts_ReturnsCorrectProducts(int[] expectedIds, int n)
        {
            IEnumerable<int> productIds = productsService.GetLatestProducts(n).Select(x => x.Id);
            Assert.True(expectedIds.SequenceEqual(productIds), $"Method should return Products with ids: {String.Join(", ", expectedIds)}");
        }

        //---- GetByName(productName) ----
        [Theory]
        [InlineData(1, "Сидни", "Сидни")]
        [InlineData(2, "Рига", "Рига")]
        [InlineData(3, "Лима", "Лима")]
        public void GetByName_ReturnsCorrectProduct(int expectedId, string expectedName, string productName)
        {
            Assert.Equal($"Product Name: {expectedName}", $"Product Name: {productsService.GetByName(productName).Name}");
            Assert.Equal($"Product ID: {expectedId}", $"Product ID: {productsService.GetByName(productName).Id}");
        }

        [Theory]
        [InlineData("Fail")]
        [InlineData("Null")]
        [InlineData("Unexisting Product")]
        public void GetByName_ReturnsNull(string productName)
        {
            Assert.Null(productsService.GetByName(productName));
        }

        //---- GetByCategoryName(categoryName) ----
        [Theory]
        [InlineData(0, "Баня")]
        [InlineData(0, "Кърпа")]
        [InlineData(0, "Кувертюри")]
        [InlineData(3, "Кърпа за ръце")]
        public void GetByCategoryName_ReturnsCorrectNumberOfProducts(int expected, string productCategory)
        {
            Assert.Equal($"Product count: {expected}", $"Product count: {productsService.GetByCategoryName(productCategory).Count()}");
        }

        [Theory]
        [InlineData(new int[] { }, "Баня")]
        [InlineData(new int[] { }, "Кърпа")]
        [InlineData(new int[] { }, "Кувертюри")]
        [InlineData(new int[] { 1, 2, 3 }, "Кърпа за ръце")]
        public void GetByCategoryName_ReturnsCorrectProducts(int[] expectedIds, string productCategory)
        {
            IEnumerable<int> productIds = productsService.GetByCategoryName(productCategory).Select(x => x.Id);
            Assert.True(expectedIds.SequenceEqual(productIds), $"Method should return Products with ids: {String.Join(", ", expectedIds)}");
        }

        //---- GetByColor(int colorId) ----
        [Theory]
        [InlineData(2, 1)]
        [InlineData(2, 2)]
        [InlineData(0, 5)]
        [InlineData(0, -1)]
        public void GetByColorById_ReturnsCorrectNumberOfProducts(int expected, int colorId)
        {
            Assert.Equal($"Product count: {expected}", $"Product count: {productsService.GetByColor(colorId).Count()}");
        }

        [Theory]
        [InlineData(new int[] { }, 5)]
        [InlineData(new int[] { }, -1)]
        [InlineData(new int[] { 1, 2 }, 1)]
        [InlineData(new int[] { 1, 2 }, 2)]
        [InlineData(new int[] { 1, 3 }, 6)]
        public void GetByColorById_ReturnsCorrectCorrectProducts(int[] expectedIds, int colorId)
        {
            IEnumerable<int> productIds = productsService.GetByColor(colorId).Select(x => x.Id);
            Assert.True(expectedIds.SequenceEqual(productIds), $"Method should return Products with ids: {String.Join(", ", expectedIds)}");
        }

        //---- GetByColor(string colorName) ----
        [Theory]
        [InlineData(2, "Зелен")]
        [InlineData(2, "Деним")]
        [InlineData(0, "Крем")]
        [InlineData(0, "Unexisting color")]
        public void GetByColorByName_ReturnsCorrectNumberOfProducts(int expected, string colorName)
        {
            Assert.Equal($"Product count: {expected}", $"Product count: {productsService.GetByColor(colorName).Count()}");
        }

        [Theory]
        [InlineData(new int[] { }, "Крем")]
        [InlineData(new int[] { }, "Unexisting color")]
        [InlineData(new int[] { 1, 2 }, "Зелен")]
        [InlineData(new int[] { 1, 2 }, "Деним")]
        [InlineData(new int[] { 1, 3 }, "Мока")]
        public void GetByColorByName_ReturnsCorrectCorrectProducts(int[] expectedIds, string colorName)
        {
            IEnumerable<int> productIds = productsService.GetByColor(colorName).Select(x => x.Id);
            Assert.True(expectedIds.SequenceEqual(productIds), $"Method should return Products with ids: {String.Join(", ", expectedIds)}");
        }

        //---- GetTopSellingProducts(n) ----
        [Theory]
        [InlineData(new int[] { }, -1)]
        [InlineData(new int[] { 2 }, 1)]
        [InlineData(new int[] { 2, 1 }, 2)]
        [InlineData(new int[] { 2, 1, 3 }, 3)]
        [InlineData(new int[] {  }, 0)]
        public void GetTopSellingProducts_ReturnsCorrectProducts(int[] expectedIds, int n)
        {
            IEnumerable<int> productIds = productsService.GetTopSellingProducts(n).Select(x => x.Id);
            Assert.True(expectedIds.SequenceEqual(productIds), $"Method should return Products with ids: {String.Join(", ", expectedIds)}");
        }

        [Theory]
        [InlineData(0, -1)]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(3, 3)]
        [InlineData(3, 4)]
        public void GetTopSellingProducts_ReturnsCorrectNumberOfProducts(int expected, int n)
        {
            Assert.Equal($"Product count: {expected}", $"Product count: {productsService.GetTopSellingProducts(n).Count()}");
        }

        //---- GetTopSellingProductsByCategory(int categoryId, int n) ----
        [Theory]
        [InlineData(2, 8, 2)]
        [InlineData(1, 8, 1)]
        [InlineData(3, 8, 3)]
        [InlineData(0, 9, 3)]
        [InlineData(0, -1, 3)]
        public void GetTopSellingProductsByCategoryId_ReturnsCorrectNumberOfProducts(int expected, int categoryId, int n)
        {
            Assert.Equal($"Product count: {expected}", $"Product count: {productsService.GetTopSellingProductsByCategory(categoryId, n).Count()}");
        }

        [Theory]
        [InlineData(new int[] { 2, 1 }, 8, 2)]
        [InlineData(new int[] { 2 }, 8, 1)]
        [InlineData(new int[] { 2, 1, 3 }, 8, 3)]
        [InlineData(new int[] { }, 9, 3)]
        [InlineData(new int[] { }, -1, 3)]
        public void GetTopSellingProductsByCategoryId_ReturnsCorrectProducts(int[] expectedIds, int categoryId, int n)
        {
            IEnumerable<int> productIds = productsService.GetTopSellingProductsByCategory(categoryId, n).Select(x => x.Id);
            Assert.True(expectedIds.SequenceEqual(productIds), $"Method should return Products with ids: {String.Join(", ", expectedIds)}");
        }

        [Theory]
        [InlineData(2, "Кърпа за ръце", 2)]
        [InlineData(1, "Кърпа за ръце", 1)]
        [InlineData(3, "Кърпа за ръце", 3)]
        [InlineData(0, "Олекотени завивки", 3)]
        [InlineData(0, "Unexisting category", 3)]
        public void GetTopSellingProductsByCategoryName_ReturnsCorrectNumberOfProducts(int expected, string categoryName, int n)
        {
            Assert.Equal($"Product count: {expected}", $"Product count: {productsService.GetTopSellingProductsByCategory(categoryName, n).Count()}");
        }

        [Theory]
        [InlineData(new int[] { 2, 1 }, "Кърпа за ръце", 2)]
        [InlineData(new int[] { 2 }, "Кърпа за ръце", 1)]
        [InlineData(new int[] { 2, 1, 3 }, "Кърпа за ръце", 3)]
        [InlineData(new int[] { }, "Олекотени завивки", 3)]
        [InlineData(new int[] { }, "Unexisting category", 3)]
        public void GetTopSellingProductsByCategoryName_ReturnsCorrectProducts(int[] expectedIds, string categoryName, int n)
        {
            IEnumerable<int> productIds = productsService.GetTopSellingProductsByCategory(categoryName, n).Select(x => x.Id);
            Assert.True(expectedIds.SequenceEqual(productIds), $"Method should return Products with ids: {String.Join(", ", expectedIds)}");
        }

        #endregion 
    }
}
