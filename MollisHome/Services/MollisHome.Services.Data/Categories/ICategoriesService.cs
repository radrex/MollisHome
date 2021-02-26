namespace MollisHome.Services.Data.Categories
{
    using MollisHome.Services.DTOs.Categories;

    using System.Collections.Generic;

    public interface ICategoriesService
    {
        IEnumerable<CategoryDTO> GetRootCategories();
    }
}
