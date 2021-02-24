namespace MollisHome.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Size
    {
        //-------------- PROPERTIES ---------------
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        //------------ ProductSize [FK] MAPPING TABLE - MANY-TO-MANY -----------
        public virtual ICollection<ProductSize> Products { get; set; } = new HashSet<ProductSize>();
    }
}
