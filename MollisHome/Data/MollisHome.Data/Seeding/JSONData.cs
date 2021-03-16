namespace MollisHome.Data.Seeding
{
    using MollisHome.Data.Models;

    using System.Collections.Generic;

    public class JSONData
    {
        public List<Gender> Genders { get; set; }
        public List<Size> Sizes { get; set; }
        public List<Material> Materials { get; set; }
        public List<Color> Colors { get; set; }
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }

        //public List<Order> Orders { get; set; }
    }
}
