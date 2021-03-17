namespace MollisHome.Data.Configurations
{
    using MollisHome.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="Category"/> entity.
    /// Applies Unique Constraint for <see cref="Category.Name"/> property.
    /// <para>Each <see cref="Category"/> has one Parent <see cref="Category"/>.</para>
    /// <para>Each <see cref="Category"/> has many <see cref="Product"/>s.</para>
    /// <para>Each <see cref="Category"/> has many <see cref="Category"/>s.</para>
    /// </summary>
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> category)
        {
            //------------------ UNIQUE ------------------
            category.HasAlternateKey(x => x.Name);

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
