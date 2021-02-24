namespace MollisHome.Data.Configurations
{
    using MollisHome.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="Product"/> entity.
    /// <para>Each <see cref="Product"/> has one <see cref="Category"/>.</para>
    /// <para>Each <see cref="Product"/> has many <see cref="Color"/>s.</para>
    /// <para>Each <see cref="Product"/> has many <see cref="Material"/>s.</para>
    /// <para>Each <see cref="Product"/> has many <see cref="Size"/>s.</para>
    /// <para>Each <see cref="Product"/> has many <see cref="Sex"/>s.</para>
    /// <para>Each <see cref="Product"/> has many <see cref="Order"/>s.</para>
    /// </summary>
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> product)
        {
            //------------------- ID's -------------------
            product.HasOne(p => p.Category)
                   .WithMany(c => c.Products)
                   .HasForeignKey(p => p.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            //--------------- COLLECTIONS ----------------
            product.HasMany(p => p.Colors)
                   .WithOne(c => c.Product)
                   .HasForeignKey(c => c.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);

            product.HasMany(p => p.Materials)
                   .WithOne(m => m.Product)
                   .HasForeignKey(m => m.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);

            product.HasMany(p => p.Sizes)
                   .WithOne(s => s.Product)
                   .HasForeignKey(s => s.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);

            product.HasMany(p => p.Sexes)
                   .WithOne(s => s.Product)
                   .HasForeignKey(s => s.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);

            product.HasMany(p => p.Orders)
                   .WithOne(s => s.Product)
                   .HasForeignKey(s => s.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
