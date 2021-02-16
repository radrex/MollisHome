namespace MollisHome.Data.Configurations
{
    using MollisHome.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="Size"/> entity.
    /// <para>Each <see cref="Size"/> has many <see cref="Product"/>s.</para>
    /// </summary>
    public class SizeConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> size)
        {
            //--------------- COLLECTIONS ----------------
            size.HasMany(s => s.Products)
                .WithOne(p => p.Size)
                .HasForeignKey(p => p.SizeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
