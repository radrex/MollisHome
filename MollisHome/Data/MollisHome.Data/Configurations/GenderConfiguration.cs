namespace MollisHome.Data.Configurations
{
    using MollisHome.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="Gender"/> entity.
    /// <para>Each <see cref="Gender"/> has many <see cref="Product"/>s.</para>
    /// </summary>
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> sex)
        {
            //--------------- COLLECTIONS ----------------
            sex.HasMany(s => s.Products)
               .WithOne(p => p.Gender)
               .HasForeignKey(p => p.GenderId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
