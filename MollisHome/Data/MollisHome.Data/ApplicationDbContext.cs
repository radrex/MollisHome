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
        public DbSet<Product> Products { get; set; }
        public DbSet<PromoCode> PromoCodes { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ItemProperty> ItemProperties { get; set; }
        public DbSet<ItemValue> ItemValues { get; set; }
        public DbSet<ProductMaterial> ProductMaterials { get; set; }
        public DbSet<ProductStock> ProductStock { get; set; }
        public DbSet<ProductCart> ProductCarts { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        //--------------- METHODS -----------------
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new MaterialConfiguration());
            builder.ApplyConfiguration(new ColorConfiguration());
            builder.ApplyConfiguration(new SizeConfiguration());
            builder.ApplyConfiguration(new GenderConfiguration());
            //builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new PromoCodeConfiguration());
            builder.ApplyConfiguration(new ProvinceConfiguration());
            builder.ApplyConfiguration(new CityConfiguration());
            builder.ApplyConfiguration(new AddressConfiguration());
            builder.ApplyConfiguration(new CartConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new ItemPropertyConfiguration());
            builder.ApplyConfiguration(new ItemValueConfiguration());
            builder.ApplyConfiguration(new ProductMaterialConfiguration());
            builder.ApplyConfiguration(new ProductStockConfiguration());
            builder.ApplyConfiguration(new ProductCartConfiguration());
            builder.ApplyConfiguration(new OrderItemConfiguration());
        }
    }
}
