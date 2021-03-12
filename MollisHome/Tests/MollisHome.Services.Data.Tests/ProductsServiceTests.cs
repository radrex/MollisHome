namespace MollisHome.Services.Data.Tests
{
    using MollisHome.Data;
    using MollisHome.Data.Seeding;
    using MollisHome.Services.Data.Products;

    using Xunit;

    using Microsoft.Extensions.DependencyInjection;

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

        //--------------- METHODS -----------------
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        [InlineData(3, 100)]
        public void GetNewestProducts_ReturnsCorrectNumberOfItems(int expected, int n)
        {
            Assert.Equal(expected, productsService.GetNewestProducts(n).Count());
        }

        [Theory]
        [InlineData(new int[] { }, -1)]
        [InlineData(new int[] { 3 }, 1)]
        [InlineData(new int[] { 3, 2 }, 2)]
        [InlineData(new int[] { 3, 2, 1 }, 3)]
        [InlineData(new int[] { 3, 2, 1 }, 100)]
        public void GetNewestProducts_ReturnsCorrectItems(int[] expectedIds, int n)
        {
            IEnumerable<int> productIds = productsService.GetNewestProducts(n).Select(x => x.Id);
            Assert.True(expectedIds.SequenceEqual(productIds));
        }
    }
}
