namespace MollisHome.Services.DTOs.Stock
{
    using MollisHome.Services.DTOs.Sizes;
    using MollisHome.Services.DTOs.Colors;
    using MollisHome.Services.DTOs.Genders;
    using MollisHome.Services.DTOs.Products;

    public class StockDTO
    {
        public int ProductId { get; set; }
        public ProductDTO Product { get; set; }

        public int GenderId { get; set; }
        public GenderDTO Gender { get; set; }

        public int SizeId { get; set; }
        public SizeDTO Size { get; set; }

        public int ColorId { get; set; }
        public ColorDTO Color { get; set; }
        
        public int Quantity { get; set; }
        public int Sold { get; set; }
        public byte DiscountPercentage { get; set; }
        public decimal Price { get; set; }
    }
}
