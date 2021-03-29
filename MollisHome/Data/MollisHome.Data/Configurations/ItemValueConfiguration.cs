namespace MollisHome.Data.Configurations
{
    using MollisHome.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="ItemValue"/> entity.
    /// Applies Unique Constraint for <see cref="ItemValue.Name"/> property.
    /// <para>Each <see cref="ItemValue"/> has many <see cref="Order"/>s.</para>
    /// </summary>
    public class ItemValueConfiguration : IEntityTypeConfiguration<ItemValue>
    {
        public void Configure(EntityTypeBuilder<ItemValue> itemValue)
        {
            //------------------ UNIQUE ------------------
            itemValue.HasIndex(x => x.Name).IsUnique();
            //itemValue.HasAlternateKey(x => x.Name);

            //--------------- COLLECTIONS ----------------
            itemValue.HasMany(ip => ip.Orders)
                     .WithOne(o => o.ItemValue)
                     .HasForeignKey(o => o.ItemValueId)
                     .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
