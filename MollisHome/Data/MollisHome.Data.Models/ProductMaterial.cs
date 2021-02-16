namespace MollisHome.Data.Models
{
    public class ProductMaterial
    {
        //------------ Product [FK] -----------
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        //------------ Material [FK] -----------
        public int MaterialId { get; set; }
        public virtual Material Material { get; set; }
    }
}
