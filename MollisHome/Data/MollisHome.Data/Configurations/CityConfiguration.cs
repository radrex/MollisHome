namespace MollisHome.Data.Configurations
{
    using MollisHome.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="City"/> many-to-many mapping entity.
    /// Applies Composite Unique Constraint for <see cref="City.Name"/> and <see cref="City.PostCode"/> properties.
    /// <para>Each <see cref="City"/> has one <see cref="Province"/> with many <see cref="City"/>s.</para>
    /// <para>Each <see cref="City"/> has many <see cref="Address"/>es.</para>
    /// </summary>
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> city)
        {
            //------------------ UNIQUE ------------------
            city.HasIndex(x => new { x.Name, x.PostCode }).IsUnique();
            //city.HasAlternateKey(x => new { x.Name, x.PostCode });

            //------------------- ID's -------------------
            city.HasOne(c => c.Province)
                .WithMany(p => p.Cities)
                .HasForeignKey(c => c.ProvinceId)
                .OnDelete(DeleteBehavior.Restrict);

            //--------------- COLLECTIONS ----------------
            city.HasMany(c => c.Addresses)
                .WithOne(a => a.City)
                .HasForeignKey(a => a.CityId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
