namespace MollisHome.Data.Models
{
    public class ProductSize
    {
        //------------ Product [FK] -----------
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        //------------ Size [FK] -----------
        public int SizeId { get; set; }
        public virtual Size Size { get; set; }
    }
}
