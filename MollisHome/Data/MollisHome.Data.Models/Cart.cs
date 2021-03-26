namespace MollisHome.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Cart : BaseModel
    {
        //------------ User [FK] - ONE-TO-ONE -----------
        [Required]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        //------------ ProductCart [FK] MAPPING TABLE - MANY-TO-MANY -----------
        public virtual ICollection<ProductCart> Products { get; set; } = new HashSet<ProductCart>();
    }
}
