namespace MollisHome.Data.Models
{
    public class ProductSex
    {
        //------------ Product [FK] -----------
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        //------------ Sex [FK] -----------
        public int SexId { get; set; }
        public virtual Sex Sex { get; set; }
    }
}
