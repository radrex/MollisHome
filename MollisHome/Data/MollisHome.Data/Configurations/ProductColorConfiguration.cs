namespace MollisHome.Data.Configurations
{
    using MollisHome.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="ProductColor"/> many-to-many mapping entity.
    /// <para>Each <see cref="ProductColor"/> has one <see cref="Product"/> with many <see cref="Color"/>s.</para>
    /// <para>Each <see cref="ProductColor"/> has one <see cref="Color"/> with many <see cref="Product"/>s.</para>
    /// </summary>
    public class ProductColorConfiguration : IEntityTypeConfiguration<ProductColor>
    {
        public void Configure(EntityTypeBuilder<ProductColor> productColor)
        {
            productColor.HasKey(pc => new { pc.ProductId, pc.ColorId });

            productColor.HasOne(pc => pc.Product)
                        .WithMany(p => p.Colors)
                        .HasForeignKey(pc => pc.ProductId)
                        .OnDelete(DeleteBehavior.Restrict);

            productColor.HasOne(pc => pc.Color)
                        .WithMany(m => m.Products)
                        .HasForeignKey(pc => pc.ColorId)
                        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
