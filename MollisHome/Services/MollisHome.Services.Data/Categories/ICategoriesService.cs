namespace MollisHome.Services.Data.Categories
{
    using MollisHome.Data.Models;

    using MollisHome.Services.Data.Base;
    using MollisHome.Services.DTOs.Categories;

    using System.Collections.Generic;

    public interface ICategoriesService : IBaseService<Category>
    {
        IEnumerable<CategoryDTO> GetRootCategories();
        CategoryDetailsDTO GetCategoryByName(string name);
    }
}
