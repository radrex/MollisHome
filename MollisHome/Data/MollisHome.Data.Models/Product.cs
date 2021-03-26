namespace MollisHome.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product : BaseModel
    {
        //-------------- PROPERTIES ---------------
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImgUrl { get; set; }

        public int Rating { get; set; }

        //------------ ONLY FOR SEEDING (Deserialized data from seed.json) - NOT MAPPED -----------
        [NotMapped]
        public int[] MaterialIds { get; set; }

        [NotMapped]
        public int[] Quantities { get; set; }

        [NotMapped]
        public int[] Sold { get; set; }

        [NotMapped]
        public int[] Prices { get; set; }

        [NotMapped]
        public int[] GenderIds { get; set; }

        [NotMapped]
        public int[] SizeIds { get; set; }

        [NotMapped]
        public int[] ColorIds { get; set; }

        //------------ Category [FK] - ONE-TO-MANY -----------
        [Required]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        //------------ ProductMaterial [FK] MAPPING TABLE - MANY-TO-MANY -----------
        public virtual ICollection<ProductMaterial> Materials { get; set; } = new HashSet<ProductMaterial>();

        //------------ ProductStock [FK] MAPPING TABLE - MANY-TO-MANY -----------
        public virtual ICollection<ProductStock> Stock { get; set; } = new HashSet<ProductStock>();

        //------------ ProductCart [FK] MAPPING TABLE - MANY-TO-MANY -----------
        public virtual ICollection<ProductCart> Carts { get; set; } = new HashSet<ProductCart>();
    }
}
