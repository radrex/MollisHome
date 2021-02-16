namespace MollisHome.Data.Configurations
{
    using MollisHome.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="Material"/> entity.
    /// <para>Each <see cref="Material"/> has many <see cref="Product"/>s.</para>
    /// </summary>
    public class MaterialConfiguration : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> material)
        {
            //--------------- COLLECTIONS ----------------
            material.HasMany(m => m.Products)
                    .WithOne(p => p.Material)
                    .HasForeignKey(p => p.MaterialId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
