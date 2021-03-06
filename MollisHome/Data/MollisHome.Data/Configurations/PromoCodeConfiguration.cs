namespace MollisHome.Data.Configurations
{
    using MollisHome.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;


    /// <summary>
    /// Applies configuration for <see cref="PromoCode"/> entity.
    /// <para>Each <see cref="PromoCode"/> has one <see cref="Order"/>.</para>
    /// <para>Each <see cref="Order"/> has one <see cref="PromoCode"/>.</para>
    /// </summary>
    public class PromoCodeConfiguration : IEntityTypeConfiguration<PromoCode>
    {
        public void Configure(EntityTypeBuilder<PromoCode> promoCode)
        {
            //------------------- ID's -------------------
            promoCode.HasOne(pc => pc.Order)
                     .WithOne(o => o.PromoCode)
                     .HasForeignKey<Order>(o => o.PromoCodeId)
                     .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
