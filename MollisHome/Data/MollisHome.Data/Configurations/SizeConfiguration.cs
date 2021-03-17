namespace MollisHome.Data.Configurations
{
    using MollisHome.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="Size"/> entity.
    /// Applies Unique Constraint for <see cref="Size.Name"/> property.
    /// <para>Each <see cref="Size"/> has many <see cref="Product"/>s.</para>
    /// </summary>
    public class SizeConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> size)
        {
            //------------------ UNIQUE ------------------
            size.HasAlternateKey(x => x.Name);

            //--------------- COLLECTIONS ----------------
            size.HasMany(s => s.Products)
                .WithOne(p => p.Size)
                .HasForeignKey(p => p.SizeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
