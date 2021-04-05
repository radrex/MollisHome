namespace MollisHome.Web.ViewModels.Products
{
    using MollisHome.Web.ViewModels.Colors;
    using MollisHome.Web.ViewModels.Genders;
    using MollisHome.Web.ViewModels.Sizes;

    public class ProductStockVM
    {
        public GenderVM Gender { get; set; }
        public SizeVM Size { get; set; }
        public ColorVM Colors { get; set; }
        public int Quantity { get; set; }
        public int Sold { get; set; }
        public int? DiscountPercentage { get; set; }
        public decimal Price { get; set; }
    }
}
