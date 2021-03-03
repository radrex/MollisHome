namespace MollisHome.Data.Models
{
    using System.Collections.Generic;

    public class Sex : BaseModel
    {
        //------------ ProductSex [FK] MAPPING TABLE - MANY-TO-MANY -----------
        public virtual ICollection<ProductSex> Products { get; set; } = new HashSet<ProductSex>();
    }
}
