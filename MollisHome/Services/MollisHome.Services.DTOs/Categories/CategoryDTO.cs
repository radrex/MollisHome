namespace MollisHome.Services.DTOs.Categories
{
    using System.Collections.Generic;

    public class CategoryDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public IEnumerable<CategoryDTO> Categories { get; set; }
    }
}
