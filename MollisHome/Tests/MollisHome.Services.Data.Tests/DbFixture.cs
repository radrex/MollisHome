namespace MollisHome.Services.Data.Tests
{
    using MollisHome.Data;
    using MollisHome.Data.Models;

    using MollisHome.Services.Data.Products;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    using System;

    public class DbFixture
    {
        //------------- CONSTRUCTORS --------------
        public DbFixture()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase(Guid.NewGuid().ToString()));
            services.AddIdentityCore<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAutoMapper(x =>
            {
                x.AddProfile(new AutoMapperDTOConfiguration());
            });

            services.AddTransient<IProductsService, ProductsService>();

            this.ServiceProvider = services.BuildServiceProvider();
        }

        //-------------- PROPERTIES ---------------
        public ServiceProvider ServiceProvider { get; private set; }
    }
}
