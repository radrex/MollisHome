namespace MollisHome.Data.Configurations
{
    using MollisHome.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="Order"/> entity.
    /// Applies Check Constraint for <see cref="Order.TotalPrice"/> property.
    /// <para>Each <see cref="Order"/> has one <see cref="ApplicationUser"/>.</para>
    /// <para>Each <see cref="Order"/> has one <see cref="PromoCode"/>.</para>
    /// <para>Each <see cref="Order"/> has many <see cref="Item"/>s.</para>
    /// </summary>
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> order)
        {
            //------------------ CHECK  ------------------
            order.HasCheckConstraint("CHK_Order_TotalPrice", "[TotalPrice] > 0");

            //------------------- ID's -------------------
            order.HasOne(o => o.User)
                 .WithMany(u => u.Orders)
                 .HasForeignKey(o => o.UserId)
                 .OnDelete(DeleteBehavior.Restrict);

            order.HasOne(o => o.PromoCode)
                 .WithOne(pc => pc.Order)
                 .HasForeignKey<Order>(o => o.PromoCodeId)
                 .OnDelete(DeleteBehavior.Restrict);

            //--------------- COLLECTIONS ----------------
            order.HasMany(o => o.Items)
                 .WithOne(i => i.Order)
                 .HasForeignKey(i => i.OrderId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
