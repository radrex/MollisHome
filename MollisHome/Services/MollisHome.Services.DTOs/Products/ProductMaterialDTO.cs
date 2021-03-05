namespace MollisHome.Services.DTOs.Products
{
    using MollisHome.Services.DTOs.Base;

    public class ProductMaterialDTO : BaseDTO
    {
        public string Name { get; set; }
        public int? Percentage { get; set; }
    }
}
