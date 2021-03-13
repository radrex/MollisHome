namespace MollisHome.Services.Data.Tests
{
    using MollisHome.Data;
    using MollisHome.Data.Seeding;
    using MollisHome.Services.Data.Products;

    using Xunit;

    using Microsoft.Extensions.DependencyInjection;

    using System.Linq;
    using System.Collections.Generic;
    using System;

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

        //--------------- METHODS -----------------
        [Fact]
        public void GetLatestProduct_ReturnsCorrectItem() //TODO: Return null if no items in db, (first delete them)
        {
            Assert.Equal("Product Name: Лима", $"Product Name: {productsService.GetLatestProduct().Name}");
            Assert.Equal("Product ID: 3", $"Product ID: {productsService.GetLatestProduct().Id}");
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        [InlineData(3, 100)]
        public void GetLatestProducts_ReturnsCorrectNumberOfItems(int expected, int n)
        {
            Assert.Equal($"Product count: {expected}", $"Product count: {productsService.GetLatestProducts(n).Count()}");
        }

        [Theory]
        [InlineData(new int[] { }, -1)]
        [InlineData(new int[] { 3 }, 1)]
        [InlineData(new int[] { 3, 2 }, 2)]
        [InlineData(new int[] { 3, 2, 1 }, 3)]
        [InlineData(new int[] { 3, 2, 1 }, 100)]
        public void GetLatestProducts_ReturnsCorrectItems(int[] expectedIds, int n)
        {
            IEnumerable<int> productIds = productsService.GetLatestProducts(n).Select(x => x.Id);
            Assert.True(expectedIds.SequenceEqual(productIds), $"Method should return Products with ids: {String.Join(", ", expectedIds)}");
        }

        [Theory]
        [InlineData(0, "Баня")]
        [InlineData(0, "Кърпа")]
        [InlineData(0, "Кувертюри")]
        [InlineData(3, "Кърпа за ръце")]
        public void GetByCategoryName_ReturnsCorrectNumberOfItems(int expected, string productCategory)
        {
            Assert.Equal($"Product count: {expected}", $"Product count: {productsService.GetByCategoryName(productCategory).Count()}");
        }

        [Theory]
        [InlineData(new int[] { }, "Баня")]
        [InlineData(new int[] { }, "Кърпа")]
        [InlineData(new int[] { }, "Кувертюри")]
        [InlineData(new int[] { 1, 2, 3 }, "Кърпа за ръце")]
        public void GetByCategoryName_ReturnsCorrectItems(int[] expectedIds, string productCategory)
        {
            IEnumerable<int> productIds = productsService.GetByCategoryName(productCategory).Select(x => x.Id);
            Assert.True(expectedIds.SequenceEqual(productIds), $"Method should return Products with ids: {String.Join(", ", expectedIds)}");
        }

        [Theory]
        [InlineData(new int[] { }, -1)]
        [InlineData(new int[] { 2 }, 1)]
        [InlineData(new int[] { 2, 1 }, 2)]
        [InlineData(new int[] { 2, 1, 3 }, 3)]
        [InlineData(new int[] {  }, 0)]
        public void GetTopSellingProducts_ReturnsCorrectItems(int[] expectedIds, int n)
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
        public void GetTopSellingProducts_ReturnsCorrectNumberOfItems(int expected, int n)
        {
            Assert.Equal($"Product count: {expected}", $"Product count: {productsService.GetTopSellingProducts(n).Count()}");
        }
    }
}
