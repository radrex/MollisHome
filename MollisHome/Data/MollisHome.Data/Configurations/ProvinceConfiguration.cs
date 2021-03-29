namespace MollisHome.Data.Configurations
{
    using MollisHome.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
    {
        /// <summary>
        /// Applies configuration for <see cref="Province"/> entity.
        /// Applies Unique Constraint for <see cref="Province.Name"/> property.
        /// <para>Each <see cref="Province"/> has many <see cref="City"/>s.</para>
        /// </summary>
        public void Configure(EntityTypeBuilder<Province> province)
        {
            //------------------ UNIQUE ------------------
            province.HasIndex(x => x.Name).IsUnique();
            //province.HasAlternateKey(x => x.Name);

            //--------------- COLLECTIONS ----------------
            province.HasMany(p => p.Cities)
                    .WithOne(c => c.Province)
                    .HasForeignKey(c => c.ProvinceId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
