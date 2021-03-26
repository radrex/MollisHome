namespace MollisHome.Data.Configurations
{
    using MollisHome.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="Address"/> many-to-many mapping entity.
    /// <para>Each <see cref="Address"/> has one <see cref="City"/> with many <see cref="Address"/>es.</para>
    /// <para>Each <see cref="Address"/> has many <see cref="Order"/>s.</para>
    /// </summary>
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> address)
        {
            //------------------- ID's -------------------
            address.HasOne(a => a.City)
                   .WithMany(c => c.Addresses)
                   .HasForeignKey(a => a.CityId)
                   .OnDelete(DeleteBehavior.Restrict);

            //--------------- COLLECTIONS ----------------
            address.HasMany(a => a.Orders)
                   .WithOne(o => o.Address)
                   .HasForeignKey(o => o.AddressId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
