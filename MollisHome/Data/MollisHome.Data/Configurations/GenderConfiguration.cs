namespace MollisHome.Data.Configurations
{
    using MollisHome.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="Gender"/> entity.
    /// Applies Unique Constraint for <see cref="Gender.Name"/> property.
    /// <para>Each <see cref="Gender"/> has many <see cref="Product"/>s.</para>
    /// </summary>
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> gender)
        {
            //------------------ UNIQUE ------------------
            gender.HasAlternateKey(x => x.Name);

            //--------------- COLLECTIONS ----------------
            gender.HasMany(s => s.Products)
               .WithOne(p => p.Gender)
               .HasForeignKey(p => p.GenderId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
