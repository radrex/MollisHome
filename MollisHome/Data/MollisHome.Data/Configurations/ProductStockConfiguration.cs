namespace MollisHome.Data.Configurations
{
    using MollisHome.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="ProductStock"/> many-to-many mapping entity.
    /// Applies Check Constraint for <see cref="ProductStock.DiscountPercentage"/> property.
    /// Applies Check Constraint for <see cref="ProductStock.Quantity"/> property.
    /// Applies Check Constraint for <see cref="ProductStock.Sold"/> property.
    /// Applies Check Constraint for <see cref="ProductStock.Price"/> property.
    /// <para>Each <see cref="ProductStock"/> has one <see cref="Product"/> with many <see cref="Gender"/>s, <see cref="Size">s and <see cref="Color">s.</para>
    /// <para>Each <see cref="ProductStock"/> has one <see cref="Gender"/> with many <see cref="Product"/>s.</para>
    /// <para>Each <see cref="ProductStock"/> has one <see cref="Size"/> with many <see cref="Product"/>s.</para>
    /// <para>Each <see cref="ProductStock"/> has one <see cref="Color"/> with many <see cref="Product"/>s.</para>
    /// </summary>
    public class ProductStockConfiguration : IEntityTypeConfiguration<ProductStock>
    {
        public void Configure(EntityTypeBuilder<ProductStock> productStock)
        {
            //------------------ CHECK  ------------------
            productStock.HasCheckConstraint("CHK_ProductStock_DiscountPercentage", "[DiscountPercentage] >= 0 AND [DiscountPercentage] <= 100");
            productStock.HasCheckConstraint("CHK_ProductStock_Quantity", "[Quantity] >= 0");
            productStock.HasCheckConstraint("CHK_ProductStock_Sold", "[Sold] >= 0");
            productStock.HasCheckConstraint("CHK_ProductStock_Price", "[Price] > 0");

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
