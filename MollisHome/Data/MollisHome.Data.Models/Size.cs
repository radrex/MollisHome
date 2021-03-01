namespace MollisHome.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Size : BaseModel
    {
        //-------------- PROPERTIES ---------------
        [Required]
        public string Name { get; set; }

        //------------ ProductSize [FK] MAPPING TABLE - MANY-TO-MANY -----------
        public virtual ICollection<ProductSize> Products { get; set; } = new HashSet<ProductSize>();
    }
}
