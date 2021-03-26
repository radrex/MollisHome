namespace MollisHome.Data.Configurations
{
    using MollisHome.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="ProductCart"/> many-to-many mapping entity.
    /// <para>Each <see cref="ProductCart"/> has one <see cref="Product"/> with many <see cref="Cart"/>s.</para>
    /// <para>Each <see cref="ProductCart"/> has one <see cref="Cart"/> with many <see cref="Product"/>s.</para>
    /// </summary>
    public class ProductCartConfiguration : IEntityTypeConfiguration<ProductCart>
    {
        public void Configure(EntityTypeBuilder<ProductCart> productCart)
        {
            //--------------- COMPOUND KEY ---------------
            productCart.HasKey(pc => new { pc.ProductId, pc.CartId });

            //------------------- ID's -------------------
            productCart.HasOne(pc => pc.Product)
                       .WithMany(p => p.Carts)
                       .HasForeignKey(pc => pc.ProductId)
                       .OnDelete(DeleteBehavior.Restrict);

            productCart.HasOne(pc => pc.Cart)
                       .WithMany(c => c.Products)
                       .HasForeignKey(pc => pc.CartId)
                       .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
