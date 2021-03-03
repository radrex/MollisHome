namespace MollisHome.Web.ViewModels.Categories
{
    using MollisHome.Web.ViewModels.Base;

    using System.Collections.Generic;

    public class CategoryVM : BaseVM
    {
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public IEnumerable<CategoryVM> Categories { get; set; }
    }
}
