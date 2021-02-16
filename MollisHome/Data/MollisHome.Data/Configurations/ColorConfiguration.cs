namespace MollisHome.Data.Configurations
{
    using MollisHome.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="Color"/> entity.
    /// <para>Each <see cref="Color"/> has many <see cref="Product"/>s.</para>
    /// </summary>
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> color)
        {
            //--------------- COLLECTIONS ----------------
            color.HasMany(c => c.Products)
                 .WithOne(p => p.Color)
                 .HasForeignKey(p => p.ColorId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
