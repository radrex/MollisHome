namespace MollisHome.Web.ViewModels.Categories
{
    using System.Collections.Generic;

    public class CategoryVM
    {
        public string Name { get; set; }
        public IEnumerable<CategoryVM> Categories { get; set; }
    }
}
