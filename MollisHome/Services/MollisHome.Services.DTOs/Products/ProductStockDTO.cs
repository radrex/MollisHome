namespace MollisHome.Services.DTOs.Products
{
    public class ProductStockDTO
    {
        public ProductSexDTO Sex { get; set; }
        public ProductSizeDTO Size { get; set; }
        public ProductColorDTO Color { get; set; }
        public int Quantity { get; set; }
        public int Sold { get; set; }
        public int? DiscountPercentage { get; set; }
        public decimal Price { get; set; }
    }
}
