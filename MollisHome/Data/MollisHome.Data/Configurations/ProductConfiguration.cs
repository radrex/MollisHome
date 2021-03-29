namespace MollisHome.Data.Configurations
{
    using MollisHome.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="Product"/> entity.
    /// Applies Composite Unique Constraint for <see cref="Product.Name"/> and <see cref="Product.CategoryId"/> properties.
    /// <para>Each <see cref="Product"/> has one <see cref="Category"/>.</para>
    /// <para>Each <see cref="Product"/> has many <see cref="Material"/>s.</para>
    /// <para>Each <see cref="Product"/> has many <see cref="Color"/>s.</para>
    /// <para>Each <see cref="Product"/> has many <see cref="Size"/>s.</para>
    /// <para>Each <see cref="Product"/> has many <see cref="Gender"/>s.</para>
    /// <para>Each <see cref="Product"/> has many <see cref="Cart"/>s.</para>
    /// </summary>
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> product)
        {
            //------------------ UNIQUE ------------------
            product.HasIndex(x => x.Name).IsUnique();
            //product.HasAlternateKey(x => new { x.Name, x.CategoryId });

            //------------------ CHECK  ------------------
            product.HasCheckConstraint("CHK_Product_Rating", "[Rating] >= 0 AND [Rating] <= 5");

            //------------------- ID's -------------------
            product.HasOne(p => p.Category)
                   .WithMany(c => c.Products)
                   .HasForeignKey(p => p.CategoryId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.Restrict);

            //--------------- COLLECTIONS ----------------
            product.HasMany(p => p.Materials)
                   .WithOne(m => m.Product)
                   .HasForeignKey(m => m.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);

            product.HasMany(p => p.Stock)
                   .WithOne(s => s.Product)
                   .HasForeignKey(s => s.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);

            product.HasMany(p => p.Carts)
                   .WithOne(c => c.Product)
                   .HasForeignKey(c => c.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
