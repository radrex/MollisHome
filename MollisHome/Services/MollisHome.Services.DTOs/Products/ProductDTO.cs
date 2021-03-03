namespace MollisHome.Services.DTOs.Products
{
    using MollisHome.Services.DTOs.Base;
    using MollisHome.Services.DTOs.Categories;

    using System.Collections.Generic;

    public class ProductDTO : BaseDTO
    {
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public CategoryDTO Category { get; set; }
        public IEnumerable<ProductSexDTO> Sexes { get; set; }
        public IEnumerable<ProductSizeDTO> Sizes { get; set; }
        public IEnumerable<ProductMaterialDTO> Materials { get; set; }
        public IEnumerable<ProductColorDTO> Colors { get; set; }
    }
}
