namespace MollisHome.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ItemProperty : BaseModel
    {
        //-------------- PROPERTIES ---------------
        [Required]
        public string Name { get; set; }

        //------------ OrderItems [FK] MAPPING TABLE - MANY-TO-MANY -----------
        public virtual ICollection<OrderItem> Orders { get; set; } = new HashSet<OrderItem>();
    }
}
