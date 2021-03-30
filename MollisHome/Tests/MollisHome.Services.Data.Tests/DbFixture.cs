namespace MollisHome.Services.Data.Tests
{
    using MollisHome.Data;
    using MollisHome.Data.Models;
    using MollisHome.Data.Seeding;

    using MollisHome.Services.Data.Products;
    using MollisHome.Services.Data.Categories;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    using System;
    using Microsoft.Data.Sqlite;

    public class DbFixture
    {
        //------------- CONSTRUCTORS --------------
        public DbFixture()
        {
            // TODO: UseSqllite in memory instead, in order to check unique constrains...
            IServiceCollection services = new ServiceCollection();
            services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase(Guid.NewGuid().ToString()));
            services.AddIdentityCore<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAutoMapper(x =>
            {
                x.AddProfile(new AutoMapperDTOConfiguration());
            });

            services.AddSingleton<IProductsService, ProductsService>();
            services.AddSingleton<ICategoriesService, CategoriesService>();

            this.ServiceProvider = services.BuildServiceProvider();

            ApplicationDbContext dbContext = this.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            new DatabaseSeeder().SeedAsync(dbContext, this.ServiceProvider).GetAwaiter().GetResult();
        }

        //-------------- PROPERTIES ---------------
        public ServiceProvider ServiceProvider { get; private set; }
    }
}
