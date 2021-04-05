namespace MollisHome.Services.DTOs.Products
{
    using MollisHome.Services.DTOs.Materials;

    public class ProductMaterialDTO
    {
        public ProductDTO Product { get; set; }
        public MaterialDTO Material { get; set; }
    }
}
