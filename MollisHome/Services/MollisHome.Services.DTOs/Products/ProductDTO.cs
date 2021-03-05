namespace MollisHome.Services.DTOs.Products
{
    using MollisHome.Services.DTOs.Base;
    using MollisHome.Services.DTOs.Categories;

    using System.Collections.Generic;

    public class ProductDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public CategoryDTO Category { get; set; }
        public IEnumerable<ProductMaterialDTO> Materials { get; set; }
        public IEnumerable<ProductStockDTO> Stock { get; set; }
    }
}
