namespace MollisHome.Data.Configurations
{
    using MollisHome.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="PromoCode"/> entity.
    /// Applies Unique Constraint for <see cref="PromoCode.Code"/> property.
    /// Applies Check Constraint for <see cref="PromoCode.DiscountPercentage"/> property.
    /// <para>Each <see cref="PromoCode"/> has one <see cref="Order"/>.</para>
    /// <para>Each <see cref="Order"/> has one <see cref="PromoCode"/>.</para>
    /// </summary>
    public class PromoCodeConfiguration : IEntityTypeConfiguration<PromoCode>
    {
        public void Configure(EntityTypeBuilder<PromoCode> promoCode)
        {
            //------------------ UNIQUE ------------------
            promoCode.HasIndex(x => new { x.Code, x.DiscountPercentage }).IsUnique();

            //------------------ CHECK  ------------------
            promoCode.HasCheckConstraint("CHK_PromoCode_DiscountPercentage", "[DiscountPercentage] >= 0 AND [DiscountPercentage] <= 100");

            //------------------- ID's -------------------
            promoCode.HasOne(pc => pc.Order)
                     .WithOne(o => o.PromoCode)
                     .HasForeignKey<Order>(o => o.PromoCodeId)
                     .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
