namespace MollisHome.Web.ViewModels.Products
{
    public class ProductStockVM
    {
        public ProductSexVM Sex { get; set; }
        public ProductSizeVM Size { get; set; }
        public ProductColorVM Color { get; set; }
        public int Quantity { get; set; }
        public int Sold { get; set; }
        public decimal Price { get; set; }
    }
}
