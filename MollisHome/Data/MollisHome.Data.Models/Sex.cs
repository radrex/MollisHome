namespace MollisHome.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Sex
    {
        //-------------- PROPERTIES ---------------
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        //------------ ProductSex [FK] MAPPING TABLE - MANY-TO-MANY -----------
        public virtual ICollection<ProductSex> Products { get; set; } = new HashSet<ProductSex>();
    }
}
