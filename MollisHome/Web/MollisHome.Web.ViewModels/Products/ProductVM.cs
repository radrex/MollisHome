namespace MollisHome.Web.ViewModels.Products
{
    using MollisHome.Web.ViewModels.Base;
    using MollisHome.Web.ViewModels.Categories;

    using System.Collections.Generic;

    public class ProductVM : BaseVM
    {
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public CategoryVM Category { get; set; }
        public IEnumerable<ProductMaterialVM> Materials { get; set; }
        public IEnumerable<ProductStockVM> Stock { get; set; }
    }
}
