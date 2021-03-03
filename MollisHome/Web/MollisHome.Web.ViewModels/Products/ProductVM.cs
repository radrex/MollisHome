namespace MollisHome.Web.ViewModels.Products
{
    using MollisHome.Web.ViewModels.Base;
    using MollisHome.Web.ViewModels.Categories;

    using System.Collections.Generic;

    public class ProductVM : BaseVM
    {
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public CategoryVM Category { get; set; }
        public IEnumerable<ProductSexVM> Sexes { get; set; }
        public IEnumerable<ProductSizeVM> Sizes { get; set; }
        public IEnumerable<ProductMaterialVM> Materials { get; set; }
        public IEnumerable<ProductColorVM> Colors { get; set; }
    }
}
