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
        public string Phone { get; set; }

        public bool IsProcessed { get; set; }

        public string TrackingNumber { get; set; }

        [Required]
        [Column(TypeName = "decimal(6,2)")]
        public decimal TotalPrice { get; set; } // Calculated property ? through user ?

        //------------ Address [FK] - ONE-TO-MANY -----------
        [Required]
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }

        //------------ User [FK] - ONE-TO-MANY -----------
        [Required]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        //------------ PromoCode [FK] - ONE-TO-ONE -----------
        [Required]
        public int? PromoCodeId { get; set; }
        public virtual PromoCode PromoCode { get; set; }

        //------------ OrderItems [FK] MAPPING TABLE - MANY-TO-MANY -----------
        public virtual ICollection<OrderItem> Items { get; set; } = new HashSet<OrderItem>();
    }
}
