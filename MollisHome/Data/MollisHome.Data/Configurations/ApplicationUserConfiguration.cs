namespace MollisHome.Data.Configurations
{
    using MollisHome.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="ApplicationUser"/> entity.
    /// <para>Each <see cref="ApplicationUser"/> has many <see cref="Order"/>s.</para>
    /// <para>Each <see cref="ApplicationUser"/> has one <see cref="Cart"/>.</para>
    /// <para>Each <see cref="Cart"/> has one <see cref="ApplicationUser"/>.</para>
    /// </summary>
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> user)
        {
            //--------------- COLLECTIONS ----------------
            user.HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            //------------------- ID's -------------------
            user.HasOne(u => u.Cart)
                .WithOne(c => c.User)
                .HasForeignKey<Cart>(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
