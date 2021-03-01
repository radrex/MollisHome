namespace MollisHome.Services.DTOs.Categories
{
    using MollisHome.Services.DTOs.Products;

    using System.Collections.Generic;

    public class CategoryDetailsDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public IEnumerable<ProductDetailsDTO> Products { get; set; }
    }
}
