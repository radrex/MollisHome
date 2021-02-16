namespace MollisHome.Data.Configurations
{
    using MollisHome.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="ProductSex"/> many-to-many mapping entity.
    /// <para>Each <see cref="ProductSex"/> has one <see cref="Product"/> with many <see cref="Sex"/>es.</para>
    /// <para>Each <see cref="ProductSex"/> has one <see cref="Sex"/> with many <see cref="Product"/>s.</para>
    /// </summary>
    public class ProductSexConfiguration : IEntityTypeConfiguration<ProductSex>
    {
        public void Configure(EntityTypeBuilder<ProductSex> productSex)
        {
            productSex.HasKey(ps => new { ps.ProductId, ps.SexId });

            productSex.HasOne(ps => ps.Product)
                      .WithMany(p => p.Sexes)
                      .HasForeignKey(ps => ps.ProductId)
                      .OnDelete(DeleteBehavior.Restrict);

            productSex.HasOne(ps => ps.Sex)
                      .WithMany(s => s.Products)
                      .HasForeignKey(ps => ps.SexId)
                      .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
