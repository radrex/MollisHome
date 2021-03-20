﻿namespace MollisHome.Data.Configurations
{
    using MollisHome.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="Order"/> entity.
    /// <para>Each <see cref="Order"/> has one <see cref="ApplicationUser"/>.</para>
    /// <para>Each <see cref="Order"/> has many <see cref="Product"/>s.</para>
    /// <para>Each <see cref="Order"/> has one <see cref="PromoCode"/>.</para>
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
            order.HasMany(o => o.Products)
                 .WithOne(p => p.Order)
                 .HasForeignKey(p => p.OrderId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
