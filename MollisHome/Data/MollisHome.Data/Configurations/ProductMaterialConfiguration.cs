namespace MollisHome.Data.Configurations
{
    using MollisHome.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="ProductMaterial"/> many-to-many mapping entity.
    /// <para>Each <see cref="ProductMaterial"/> has one <see cref="Product"/> with many <see cref="Material"/>s.</para>
    /// <para>Each <see cref="ProductMaterial"/> has one <see cref="Material"/> with many <see cref="Product"/>s.</para>
    /// </summary>
    public class ProductMaterialConfiguration : IEntityTypeConfiguration<ProductMaterial>
    {
        public void Configure(EntityTypeBuilder<ProductMaterial> productMaterial)
        {
            productMaterial.HasKey(pm => new { pm.ProductId, pm.MaterialId });

            productMaterial.HasOne(pm => pm.Product)
                           .WithMany(p => p.Materials)
                           .HasForeignKey(pm => pm.ProductId)
                           .OnDelete(DeleteBehavior.Restrict);

            productMaterial.HasOne(pm => pm.Material)
                           .WithMany(m => m.Products)
                           .HasForeignKey(pm => pm.MaterialId)
                           .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
