namespace MollisHome.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Sex : BaseModel
    {
        //-------------- PROPERTIES ---------------
        [Required]
        public string Name { get; set; }

        //------------ ProductStock [FK] MAPPING TABLE - MANY-TO-MANY -----------
        public virtual ICollection<ProductStock> Products { get; set; } = new HashSet<ProductStock>();
    }
}
