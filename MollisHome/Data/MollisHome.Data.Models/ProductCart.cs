namespace MollisHome.Data.Models
{
    public class ProductCart
    {
        //------------ Product [FK] -----------
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        //------------ Material [FK] -----------
        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
