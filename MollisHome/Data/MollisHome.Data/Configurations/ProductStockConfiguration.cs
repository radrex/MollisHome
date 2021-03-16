namespace MollisHome.Data.Configurations
{
    using MollisHome.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="ProductStock"/> many-to-many mapping entity.
    /// <para>Each <see cref="ProductStock"/> has one <see cref="Product"/> with many <see cref="Gender"/>es, <see cref="Size">s and <see cref="Color">s.</para>
    /// <para>Each <see cref="ProductStock"/> has one <see cref="Gender"/> with many <see cref="Product"/>s.</para>
    /// <para>Each <see cref="ProductStock"/> has one <see cref="Size"/> with many <see cref="Product"/>s.</para>
    /// <para>Each <see cref="ProductStock"/> has one <see cref="Color"/> with many <see cref="Product"/>s.</para>
    /// </summary>
    public class ProductStockConfiguration : IEntityTypeConfiguration<ProductStock>
    {
        public void Configure(EntityTypeBuilder<ProductStock> productStock)
        {
            //--------------- COMPOUND KEY ---------------
            productStock.HasKey(ps => new { ps.ProductId, ps.GenderId, ps.SizeId, ps.ColorId });

            //------------------- ID's -------------------
            productStock.HasOne(ps => ps.Product)
                        .WithMany(p => p.Stock)
                        .HasForeignKey(ps => ps.ProductId)
                        .OnDelete(DeleteBehavior.Restrict);

            productStock.HasOne(ps => ps.Gender)
                        .WithMany(p => p.Products)
                        .HasForeignKey(ps => ps.GenderId)
                        .OnDelete(DeleteBehavior.Restrict);

            productStock.HasOne(ps => ps.Size)
                        .WithMany(p => p.Products)
                        .HasForeignKey(ps => ps.SizeId)
                        .OnDelete(DeleteBehavior.Restrict);

            productStock.HasOne(ps => ps.Color)
                        .WithMany(p => p.Products)
                        .HasForeignKey(ps => ps.ColorId)
                        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
