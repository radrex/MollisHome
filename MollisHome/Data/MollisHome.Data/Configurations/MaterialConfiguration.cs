namespace MollisHome.Data.Configurations
{
    using MollisHome.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="Material"/> entity.
    /// Applies Composite Unique Constraint for <see cref="Material.Name"/> and <see cref="Material.Percentage"/> properties.
    /// Applies Check Constraint for <see cref="Material.Percentage"/> property.
    /// <para>Each <see cref="Material"/> has many <see cref="Product"/>s.</para>
    /// </summary>
    public class MaterialConfiguration : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> material)
        {
            //------------------ UNIQUE ------------------
            material.HasAlternateKey(x => new { x.Name, x.Percentage });

            //------------------ CHECK  ------------------
            material.HasCheckConstraint("CHK_Material_Percentage", "[Percentage] >= 0 AND [Percentage] <= 100");

            //--------------- COLLECTIONS ----------------
            material.HasMany(m => m.Products)
                    .WithOne(p => p.Material)
                    .HasForeignKey(p => p.MaterialId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
