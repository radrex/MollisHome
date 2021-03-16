namespace MollisHome.Data
{
    using MollisHome.Data.Models;
    using MollisHome.Data.Configurations;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    /// <summary>
    /// Base class responsible for managing database connections, providing all sorts of DB related functionality like data access methods to interact with Database. 
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext
    {
        //------------- CONSTRUCTORS --------------
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //-------------- PROPERTIES ---------------
        public DbSet<Material> Materials { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PromoCode> PromoCodes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductMaterial> ProductMaterials { get; set; }
        public DbSet<ProductStock> ProductStock { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }

        //--------------- METHODS -----------------
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new GenderConfiguration());
            builder.ApplyConfiguration(new SizeConfiguration());
            builder.ApplyConfiguration(new ColorConfiguration());
            builder.ApplyConfiguration(new MaterialConfiguration());
            builder.ApplyConfiguration(new PromoCodeConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ProductMaterialConfiguration());
            builder.ApplyConfiguration(new ProductStockConfiguration());
            builder.ApplyConfiguration(new ProductOrderConfiguration());
        }
    }
}
