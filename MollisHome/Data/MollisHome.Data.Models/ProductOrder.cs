namespace MollisHome.Data.Models
{
    public class ProductOrder
    {
        //------------ Product [FK] -----------
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        //------------ Order [FK] -----------
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
