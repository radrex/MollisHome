namespace MollisHome.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ProductStock
    {
        //------------ Product [FK] -----------
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        //------------ Sex [FK] -----------
        public int GenderId { get; set; }
        public virtual Gender Gender { get; set; }

        //------------ Size [FK] -----------
        public int SizeId { get; set; }
        public virtual Size Size { get; set; }

        //------------ Color [FK] -----------
        public int ColorId { get; set; }
        public virtual Color Color { get; set; }

        //-------------- PROPERTIES ---------------
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }

        public byte DiscountPercentage { get; set; }

        public int Sold { get; set; }
    }
}
