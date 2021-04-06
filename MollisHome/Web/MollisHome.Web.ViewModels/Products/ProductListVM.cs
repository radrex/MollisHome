namespace MollisHome.Web.ViewModels.Products
{
    using System.Collections.Generic;

    public class ProductListVM
    {
        public IEnumerable<ProductVM> Products { get; set; }
        public int CurrentPage { get; set; }
        public int PagesCount { get; set; }
    }
}
