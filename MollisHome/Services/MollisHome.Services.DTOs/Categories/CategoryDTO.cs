namespace MollisHome.Services.DTOs.Categories
{
    using System.Collections.Generic;

    public class CategoryDTO
    {
        public string Name { get; set; }
        public IEnumerable<CategoryDTO> Categories { get; set; }
    }
}
