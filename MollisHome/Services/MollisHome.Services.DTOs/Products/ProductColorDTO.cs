namespace MollisHome.Services.DTOs.Products
{
    using MollisHome.Services.DTOs.Base;

    public class ProductColorDTO : BaseDTO
    {
        public string Name { get; set; }
        public string HexValue { get; set; }
    }
}
