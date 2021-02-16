namespace MollisHome.Data.Configurations
{
    using MollisHome.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="Sex"/> entity.
    /// <para>Each <see cref="Sex"/> has many <see cref="Product"/>s.</para>
    /// </summary>
    public class SexConfiguration : IEntityTypeConfiguration<Sex>
    {
        public void Configure(EntityTypeBuilder<Sex> sex)
        {
            //--------------- COLLECTIONS ----------------
            sex.HasMany(s => s.Products)
               .WithOne(p => p.Sex)
               .HasForeignKey(p => p.SexId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
