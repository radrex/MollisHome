namespace MollisHome.Services.DTOs.Products
{
    using MollisHome.Services.DTOs.Base;
    using MollisHome.Services.DTOs.Stock;
    using MollisHome.Services.DTOs.Categories;

    using System.Collections.Generic;

    public class ProductDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }

        public int? CategoryId { get; set; }
        public CategoryDTO Category { get; set; }

        public int[] MaterialIds { get; set; }
        public IEnumerable<ProductMaterialDTO> Materials { get; set; }

        public int ColorId { get; set; }
        public int GenderId { get; set; }
        public int SizeId { get; set; }
        public IEnumerable<StockDTO> Stock { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public byte DiscountPercentage { get; set; }
    }
}
