namespace MollisHome.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Color
    {
        //-------------- PROPERTIES ---------------
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string HexValue { get; set; }

        //------------ Product [FK] - ONE-TO-MANY -----------
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
