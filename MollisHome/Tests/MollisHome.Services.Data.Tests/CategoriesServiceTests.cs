namespace MollisHome.Services.Data.Tests
{
    using MollisHome.Data;
    using MollisHome.Data.Seeding;
    using MollisHome.Services.Data.Categories;

    using Xunit;

    using Microsoft.Extensions.DependencyInjection;

    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class CategoriesServiceTests : IClassFixture<DbFixture>
    {
        //---------------- FIELDS -----------------
        private ServiceProvider serviceProvider;

        //------------- CONSTRUCTORS --------------
        public CategoriesServiceTests(DbFixture fixture)
        {
            this.serviceProvider = fixture.ServiceProvider;
            ApplicationDbContext dbContext = this.serviceProvider.GetRequiredService<ApplicationDbContext>();
            new DatabaseSeeder().SeedAsync(dbContext, this.serviceProvider).GetAwaiter().GetResult();
            this.categoriesService = this.serviceProvider.GetRequiredService<ICategoriesService>();
        }

        //-------------- PROPERTIES ---------------
        private ICategoriesService categoriesService { get; }

        //--------------- BASE METHODS -----------------
        #region CategoriesServiceBase Tests
        //---- HasEntities() ----
        [Fact]
        public void HasEntities_ReturnsTrue()
        {
            Assert.True(categoriesService.HasEntities(), "Method should return TRUE.");
        }

        [Fact]
        public void HasEntities_ReturnsFalse()
        {
            //TODO: Delete all entities and assert
            Assert.False(categoriesService.HasEntities(), "Method should return FALSE.");
        }

        //---- GetAll() ----
        [Theory]
        [InlineData(13)]
        public void GetAll_ReturnsCorrectNumberOfCategories(int categoriesCount)
        {
            Assert.Equal($"Categories count: {categoriesCount}", $"Categories count: {categoriesService.GetAll().Count()}");
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 })]
        public void GetAll_ReturnsCorrectCategories(int[] expectedIds)
        {
            IEnumerable<int> categoryIds = categoriesService.GetAll().Select(x => x.Id);
            Assert.True(expectedIds.SequenceEqual(categoryIds), $"Method should return categories with ids: {String.Join(", ", expectedIds)}");
        }

        //---- GetById(int id) ----
        [Theory]
        [InlineData(1, "Баня", 1)]
        [InlineData(10, "Протектори", 10)]
        [InlineData(13, "Кувертюри", 13)]
        public void GetById_ReturnsCorrectCategory(int expectedId, string expectedName, int id)
        {
            Assert.Equal($"Category ID: {expectedId}", $"Category ID: {categoriesService.GetById(id).Id}");
            Assert.Equal($"Category Name: {expectedName}", $"Category Name: {categoriesService.GetById(id).Name}");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void GetById_ReturnsNull(int id)
        {
            Assert.Null(categoriesService.GetById(id));
        }

        //TODO: write tests for these methods
        //---- Create(Category category) ----
        //---- Update(Category category) ----
        //---- Save(Category category) ----
        //---- Delete(int id) ----

        #endregion

        //--------------- CHILD METHODS -----------------
        #region CategoriesServiceChild Tests

        //---- HasProducts(int categoryId) ----
        [Theory]
        [InlineData(8)]
        public void HasProductsById_ReturnsTrue(int categoryId)
        {
            Assert.True(categoriesService.HasProducts(categoryId), "Method should return TRUE.");
        }

        [Theory]
        [InlineData(8)]
        public void HasProductsById_ReturnsFalse(int categoryId)
        {
            //TODO: Delete all category products and assert
            Assert.False(categoriesService.HasProducts(categoryId), "Method should return FALSE.");
        }

        //---- HasProducts(string categoryName) ----
        [Theory]
        [InlineData("Кърпа за ръце")]
        public void HasProductsByName_ReturnsTrue(string categoryName)
        {
            Assert.True(categoriesService.HasProducts(categoryName), "Method should return TRUE.");
        }

        [Theory]
        [InlineData("Кърпа за ръце")]
        public void HasProductsByName_ReturnsFalse(string categoryName)
        {
            //TODO: Delete all category products and assert
            Assert.False(categoriesService.HasProducts(categoryName), "Method should return FALSE.");
        }

        //---- HasParentCategory(int categoryId) ----
        [Theory]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(11)]
        [InlineData(12)]
        [InlineData(13)]
        public void HasParentCategory_ReturnsTrue(int id)
        {
            Assert.True(categoriesService.HasParentCategory(id), "Method should return TRUE.");
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void HasParentCategoryById_ReturnsFalse(int id)
        {
            Assert.False(categoriesService.HasParentCategory(id), "Method should return FALSE.");
        }

        //---- HasParentCategory(string categoryName) ----
        [Theory]
        [InlineData("Халат")]
        [InlineData("Кърпа")]
        [InlineData("Спално бельо")]
        [InlineData("Одеяла")]
        [InlineData("Кувертюри")]
        public void HasParentCategoryByName_ReturnsTrue(string categoryName)
        {
            Assert.True(categoriesService.HasParentCategory(categoryName), "Method should return TRUE.");
        }

        [Theory]
        [InlineData("Баня")]
        [InlineData("Кухня")]
        [InlineData("Спалня")]
        public void HasParentCategoryByName_ReturnsFalse(string categoryName)
        {
            Assert.False(categoriesService.HasParentCategory(categoryName), "Method should return FALSE.");
        }

        //---- GetByName(string name) ----
        [Theory]
        [InlineData(1, "Баня", "Баня")]
        [InlineData(8, "Кърпа за ръце", "Кърпа за ръце")]
        [InlineData(13, "Кувертюри", "Кувертюри")]
        public void GetByName_ReturnsCorrectCategory(int expectedId, string expectedName, string categoryName)
        {
            Assert.Equal($"Category ID: {expectedId}", $"Category ID: {categoriesService.GetByName(categoryName).Id}");
            Assert.Equal($"Category Name: {expectedName}", $"Category Name: {categoriesService.GetByName(categoryName).Name}");
        }

        [Theory]
        [InlineData("Fail")]
        [InlineData("Null")]
        [InlineData("Unexisting Category")]
        public void GetByName_ReturnsNull(string categoryName)
        {
            Assert.Null(categoriesService.GetByName(categoryName));
        }

        //---- GetParentCategory(int categoryId) ----
        [Theory]
        [InlineData(3, 13)]
        [InlineData(5, 8)]
        [InlineData(1, 5)]
        public void GetParentCategoryById_ReturnsCorrectParentCategory(int expectedCategoryId, int categoryId)
        {
            Assert.Equal($"Parent Category ID: {expectedCategoryId}", $"Parent Category ID: {categoriesService.GetParentCategory(categoryId).Id}");
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetParentCategoryById_ReturnsNull(int categoryId)
        {
            Assert.Null(categoriesService.GetParentCategory(categoryId));
        }

        //---- GetParentCategory(string categoryName) ----
        [Theory]
        [InlineData(3, "Кувертюри")]
        [InlineData(5, "Кърпа за ръце")]
        [InlineData(1, "Кърпа")]
        public void GetParentCategoryByName_ReturnsCorrectParentCategory(int expectedCategoryId, string categoryName)
        {
            Assert.Equal($"Parent Category ID: {expectedCategoryId}", $"Parent Category ID: {categoriesService.GetParentCategory(categoryName).Id}");
        }

        [Theory]
        [InlineData("Баня")]
        [InlineData("Кухня")]
        [InlineData("Спалня")]
        public void GetParentCategoryByName_ReturnsNull(string categoryName)
        {
            Assert.Null(categoriesService.GetParentCategory(categoryName));
        }

        //---- GetRootCategories() ----
        [Fact]
        public void GetRootCategories_ReturnsCorrectNumberOfCategories()
        {
            Assert.Equal($"Category count: {3}", $"Category count: {categoriesService.GetRootCategories().Count()}");
            //TODO: delete categories, assert again with count: 0
        }

        [Fact]
        public void GetRootCategories_ReturnsCorrectRootCategories()
        {
            int[] expectedIds = new int[] { 1, 2, 3 };
            IEnumerable<int> categoryIds = categoriesService.GetRootCategories().Select(x => x.Id);
            Assert.True(categoryIds.SequenceEqual(expectedIds), $"Method should return Categories with ids: {String.Join(", ", expectedIds)}");

            //TODO: delete categories, assert again with empty expectedIds arr
        }

        #endregion
    }
}
