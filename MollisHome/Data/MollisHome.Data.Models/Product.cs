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

        //------------ ONLY FOR SEEDING - NOT MAPPED -----------
        [NotMapped]
        public int[] SexIds { get; set; }

        [NotMapped]
        public int[] SizeIds { get; set; }

        [NotMapped]
        public int[] MaterialIds { get; set; }

        [NotMapped]
        public int[] ColorIds { get; set; }

        //------------ Category [FK] - ONE-TO-MANY -----------
        [Required]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        //------------ ProductColor [FK] MAPPING TABLE - MANY-TO-MANY -----------
        public virtual ICollection<ProductColor> Colors { get; set; } = new HashSet<ProductColor>();

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
