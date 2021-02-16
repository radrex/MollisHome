namespace MollisHome.Data.Configurations
{
    using MollisHome.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="ProductOrder"/> many-to-many mapping entity.
    /// <para>Each <see cref="ProductOrder"/> has one <see cref="Product"/> with many <see cref="Order"/>s.</para>
    /// <para>Each <see cref="ProductOrder"/> has one <see cref="Order"/> with many <see cref="Product"/>s.</para>
    /// </summary>
    public class ProductOrderConfiguration : IEntityTypeConfiguration<ProductOrder>
    {
        public void Configure(EntityTypeBuilder<ProductOrder> productOrder)
        {
            productOrder.HasKey(po => new { po.ProductId, po.OrderId });

            productOrder.HasOne(po => po.Product)
                        .WithMany(p => p.Orders)
                        .HasForeignKey(po => po.ProductId)
                        .OnDelete(DeleteBehavior.Restrict);

            productOrder.HasOne(po => po.Order)
                        .WithMany(s => s.Products)
                        .HasForeignKey(po => po.OrderId)
                        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
