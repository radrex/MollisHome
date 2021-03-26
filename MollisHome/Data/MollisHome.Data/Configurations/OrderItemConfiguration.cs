namespace MollisHome.Data.Configurations
{
    using MollisHome.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="OrderItem"/> many-to-many mapping entity.
    /// Applies Check Constraint for <see cref="OrderItem.Quantity"/> property.
    /// Applies Check Constraint for <see cref="OrderItem.Price"/> property.
    /// Applies Check Constraint for <see cref="OrderItem.Discount"/> property.
    /// Applies Check Constraint for <see cref="OrderItem.TotalPrice"/> property.
    /// <para>Each <see cref="OrderItem"/> has one <see cref="Order"/> with many <see cref="OrderItem"/>s.</para>
    /// <para>Each <see cref="OrderItem"/> has one <see cref="ItemProperty"/> with many <see cref="Order"/>s.</para>
    /// <para>Each <see cref="OrderItem"/> has one <see cref="ItemValue"/> with many <see cref="Order"/>s.</para>
    /// </summary>
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> orderItem)
        {
            //--------------- COMPOUND KEY ---------------
            orderItem.HasKey(oi => new { oi.OrderId, oi.ItemPropertyId, oi.ItemValueId });

            //------------------ CHECK  ------------------
            orderItem.HasCheckConstraint("CHK_OrderItem_Quantity", "[Quantity] > 0");
            orderItem.HasCheckConstraint("CHK_OrderItem_Price", "[Price] > 0");
            orderItem.HasCheckConstraint("CHK_OrderItem_Discount", "[Discount] >= 0");
            orderItem.HasCheckConstraint("CHK_OrderItem_TotalPrice", "[TotalPrice] > 0");

            //------------------- ID's -------------------
            orderItem.HasOne(oi => oi.Order)
                     .WithMany(o => o.Items)
                     .HasForeignKey(oi => oi.OrderId)
                     .OnDelete(DeleteBehavior.Restrict);

            orderItem.HasOne(oi => oi.ItemProperty)
                     .WithMany(ip => ip.Orders)
                     .HasForeignKey(oi => oi.ItemPropertyId)
                     .OnDelete(DeleteBehavior.Restrict);

            orderItem.HasOne(oi => oi.ItemValue)
                     .WithMany(iv => iv.Orders)
                     .HasForeignKey(oi => oi.ItemValueId)
                     .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
