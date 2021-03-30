namespace MollisHome.Data.Configurations
{
    using MollisHome.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="Color"/> entity.
    /// Applies Unique Constraint for <see cref="Color.Name"/> property.
    /// <para>Each <see cref="Color"/> has many <see cref="Product"/>s.</para>
    /// </summary>
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> color)
        {
            //------------------ UNIQUE ------------------
            color.HasIndex(x => x.Name).IsUnique();

            //--------------- COLLECTIONS ----------------
            color.HasMany(c => c.Products)
                 .WithOne(p => p.Color)
                 .HasForeignKey(p => p.ColorId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
