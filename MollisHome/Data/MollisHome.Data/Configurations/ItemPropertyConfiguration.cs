namespace MollisHome.Data.Configurations
{
    using MollisHome.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="ItemProperty"/> entity.
    /// Applies Unique Constraint for <see cref="ItemProperty.Name"/> property.
    /// <para>Each <see cref="ItemProperty"/> has many <see cref="Order"/>s.</para>
    /// </summary>
    public class ItemPropertyConfiguration : IEntityTypeConfiguration<ItemProperty>
    {
        public void Configure(EntityTypeBuilder<ItemProperty> itemProperty)
        {
            //------------------ UNIQUE ------------------
            itemProperty.HasAlternateKey(x => x.Name);

            //--------------- COLLECTIONS ----------------
            itemProperty.HasMany(ip => ip.Orders)
                        .WithOne(o => o.ItemProperty)
                        .HasForeignKey(o => o.ItemPropertyId)
                        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
