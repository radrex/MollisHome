namespace MollisHome.Services.Data.Categories
{
    using MollisHome.Data.Models;

    using MollisHome.Services.Data.Base;
    using MollisHome.Services.DTOs.Categories;

    using System.Collections.Generic;

    public interface ICategoriesService : IBaseService<Category, CategoryDTO>
    {
        bool HasProducts(int categoryId);
        bool HasProducts(string categoryName);
        bool HasParentCategory(int categoryId);
        bool HasParentCategory(string categoryName);

        CategoryDTO GetByName(string categoryName);
        CategoryDTO GetParentCategory(int categoryId);
        CategoryDTO GetParentCategory(string categoryName);
        IEnumerable<CategoryDTO> GetRootCategories();
    }
}
