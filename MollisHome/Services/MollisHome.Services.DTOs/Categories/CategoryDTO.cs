namespace MollisHome.Services.DTOs.Categories
{
    using MollisHome.Services.DTOs.Base;
    using MollisHome.Services.DTOs.Products;
    using System.Collections.Generic;

    public class CategoryDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public CategoryDTO ParentCategory { get; set; }
        public IEnumerable<CategoryDTO> Categories { get; set; }

        //public IEnumerable<ProductDTO> Products { get; set; }
    }
}
