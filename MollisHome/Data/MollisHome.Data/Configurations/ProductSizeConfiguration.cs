namespace MollisHome.Data.Configurations
{
    using MollisHome.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="ProductSize"/> many-to-many mapping entity.
    /// <para>Each <see cref="ProductSize"/> has one <see cref="Product"/> with many <see cref="Size"/>s.</para>
    /// <para>Each <see cref="ProductSize"/> has one <see cref="Size"/> with many <see cref="Product"/>s.</para>
    /// </summary>
    public class ProductSizeConfiguration : IEntityTypeConfiguration<ProductSize>
    {
        public void Configure(EntityTypeBuilder<ProductSize> productSize)
        {
            productSize.HasKey(ps => new { ps.ProductId, ps.SizeId });

            productSize.HasOne(ps => ps.Product)
                       .WithMany(p => p.Sizes)
                       .HasForeignKey(ps => ps.ProductId)
                       .OnDelete(DeleteBehavior.Restrict);

            productSize.HasOne(ps => ps.Size)
                       .WithMany(s => s.Products)
                       .HasForeignKey(ps => ps.SizeId)
                       .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
