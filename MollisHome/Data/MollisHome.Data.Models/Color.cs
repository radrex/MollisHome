namespace MollisHome.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Color : BaseModel
    {
        //-------------- PROPERTIES ---------------
        [Required]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "char(7)")]
        public string HexValue { get; set; }

        //------------ ProductStock [FK] MAPPING TABLE - MANY-TO-MANY -----------
        public virtual ICollection<ProductStock> Products { get; set; } = new HashSet<ProductStock>();
    }
}
