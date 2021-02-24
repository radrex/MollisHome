namespace MollisHome.Data.Models
{
    public class ProductColor
    {
        //------------ Product [FK] -----------
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        //------------ Color [FK] -----------
        public int ColorId { get; set; }
        public virtual Color Color { get; set; }
    }
}
