namespace MollisHome.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class OrderItem
    {
        //------------ Order [FK] -----------
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        //------------ ItemProperty [FK] -----------
        public int ItemPropertyId { get; set; }
        public virtual ItemProperty ItemProperty { get; set; }

        //------------ ItemValue [FK] -----------
        public int ItemValueId { get; set; }
        public virtual ItemValue ItemValue { get; set; }

        //-------------- PROPERTIES ---------------
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }

        [Required]
        [Column(TypeName = "decimal(6,2)")]
        public decimal Discount { get; set; }

        [Required]
        [Column(TypeName = "decimal(6,2)")]
        public decimal TotalPrice { get; set; }
    }
}
