namespace MollisHome.Web.InputModels.Products
{
    using MollisHome.Web.ViewModels.Categories;

    using System.Collections.Generic;

    public class ProductIM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public int? CategoryId { get; set; }

        //-------- USED FOR DROPDOWN LISTING --------
        public int[] CategoryIds { get; set; }
        public IEnumerable<CategoryVM> Categories { get; set; }
    }
}
