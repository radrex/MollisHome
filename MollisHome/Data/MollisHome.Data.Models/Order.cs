namespace MollisHome.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Order : BaseModel
    {
        //-------------- PROPERTIES ---------------
        [Required]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        [Column(TypeName = "decimal(6,2)")]
        public decimal TotalPrice { get; set; }

        //------------ User [FK] - ONE-TO-MANY -----------
        [Required]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        //------------ PromoCode [FK] - ONE-TO-ONE -----------
        [Required]
        public int? PromoCodeId { get; set; }
        public virtual PromoCode PromoCode { get; set; }

        //------------ ProductOrder [FK] MAPPING TABLE - MANY-TO-MANY -----------
        public virtual ICollection<ProductOrder> Products { get; set; } = new HashSet<ProductOrder>();
    }
}
