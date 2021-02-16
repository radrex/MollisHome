namespace MollisHome.Data.Configurations
{
    using MollisHome.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> category)
        {
            //------------------- ID's -------------------
            category.HasOne(c => c.ParentCategory)
                    .WithMany(pc => pc.Categories)
                    .HasForeignKey(c => c.ParentCategoryId)
                    .OnDelete(DeleteBehavior.Restrict);

            //--------------- COLLECTIONS ----------------
            category.HasMany(c => c.Products)
                    .WithOne(p => p.Category)
                    .HasForeignKey(p => p.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);

            category.HasMany(c => c.Categories)
                    .WithOne(c => c.ParentCategory)
                    .HasForeignKey(c => c.ParentCategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
