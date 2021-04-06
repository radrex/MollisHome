namespace MollisHome.Web.ViewModels.Products
{
    using MollisHome.Web.ViewModels.Categories;

    using System.Collections.Generic;

    public class ProductVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public CategoryVM Category { get; set; }
        public IEnumerable<ProductMaterialVM> Materials { get; set; }
        public IEnumerable<StockVM> Stock { get; set; }
    }
}
