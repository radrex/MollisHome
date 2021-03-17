namespace MollisHome.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Category : BaseModel
    {
        //-------------- PROPERTIES ---------------
        [Required]
        [Column(TypeName = "nvarchar(450)")] // Using this for UNIQUE Constraint, because migration is causing problems. Also add UNIQUE Constraint for this column manually in migration.
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImgUrl { get; set; }

        //------------ Category [FK] - ONE-TO-MANY - PARENT -----------
        public int? ParentCategoryId { get; set; }
        public virtual Category ParentCategory { get; set; }

        //------------ Category [FK] - ONE-TO-MANY - CHILDREN -----------
        public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>();

        //------------ Product [FK] - ONE-TO-MANY -----------
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
