namespace MollisHome.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Material : BaseModel
    {
        //-------------- PROPERTIES ---------------
        [Required]
        public string Name { get; set; }

        public int? Percentage { get; set; } // nullable int, in case we don't know the percentage

        //------------ ProductMaterial [FK] MAPPING TABLE - MANY-TO-MANY -----------
        public virtual ICollection<ProductMaterial> Products { get; set; } = new HashSet<ProductMaterial>();
    }
}
