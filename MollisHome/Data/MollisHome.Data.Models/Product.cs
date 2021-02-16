namespace MollisHome.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        //-------------- PROPERTIES ---------------
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImgUrl { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }

        //------------ Color [FK] - ONE-TO-MANY -----------
        [Required]
        public int ColorId { get; set; }
        public virtual Color Color { get; set; }

        //------------ Category [FK] - ONE-TO-MANY -----------
        [Required]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        //------------ ProductMaterial [FK] MAPPING TABLE - MANY-TO-MANY -----------
        public virtual ICollection<ProductMaterial> Materials { get; set; } = new HashSet<ProductMaterial>();

        //------------ ProductSex [FK] MAPPING TABLE - MANY-TO-MANY -----------
        public virtual ICollection<ProductSex> Sexes { get; set; } = new HashSet<ProductSex>();

        //------------ ProductSize [FK] MAPPING TABLE - MANY-TO-MANY -----------
        public virtual ICollection<ProductSize> Sizes { get; set; } = new HashSet<ProductSize>();

        //------------ ProductOrder [FK] MAPPING TABLE - MANY-TO-MANY -----------
        public virtual ICollection<ProductOrder> Orders { get; set; } = new HashSet<ProductOrder>();
    }
}
