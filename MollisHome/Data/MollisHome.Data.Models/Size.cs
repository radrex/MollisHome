namespace MollisHome.Data.Models
{
    using System.Collections.Generic;

    public class Size : BaseModel
    {
        //------------ ProductSize [FK] MAPPING TABLE - MANY-TO-MANY -----------
        public virtual ICollection<ProductSize> Products { get; set; } = new HashSet<ProductSize>();
    }
}
