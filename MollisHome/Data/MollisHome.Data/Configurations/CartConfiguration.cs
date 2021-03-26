namespace MollisHome.Data.Configurations
{
    using MollisHome.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="Cart"/> many-to-many mapping entity.
    /// <para>Each <see cref="Cart"/> has one <see cref="ApplicationUser"/>.</para>
    /// <para>Each <see cref="Cart"/> has many <see cref="Product"/>s.</para>
    /// </summary>
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> cart)
        {
            //------------------- ID's -------------------
            cart.HasOne(c => c.User)
                .WithOne(u => u.Cart)
                .HasForeignKey<Cart>(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            //--------------- COLLECTIONS ----------------
            cart.HasMany(c => c.Products)
                .WithOne(p => p.Cart)
                .HasForeignKey(p => p.CartId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
