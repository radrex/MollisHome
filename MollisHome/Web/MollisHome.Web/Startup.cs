namespace MollisHome.Web
{
    using MollisHome.Data;
    using MollisHome.Data.Models;
    using MollisHome.Data.Seeding;

    using MollisHome.Services.Data;
    using MollisHome.Services.Data.Sizes;
    using MollisHome.Services.Data.Colors;
    using MollisHome.Services.Data.Cities;
    using MollisHome.Services.Data.Genders;
    using MollisHome.Services.Data.Products;
    using MollisHome.Services.Data.Provinces;
    using MollisHome.Services.Data.Addresses;
    using MollisHome.Services.Data.Materials;
    using MollisHome.Services.Data.Categories;

    using MollisHome.Web.ViewModels;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.HttpsPolicy;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        //------------- CONSTRUCTORS --------------
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        //-------------- PROPERTIES ---------------
        public IConfiguration Configuration { get; }

        //--------------- METHODS -----------------
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseLazyLoadingProxies().UseSqlServer(this.Configuration.GetConnectionString("DbConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAutoMapper(x =>
            {
                x.AddProfile(new AutoMapperDTOConfiguration());
                x.AddProfile(new AutoMapperVMConfiguration());
            });

            // Application services
            services.AddTransient<ICategoriesService, CategoriesService>();
            services.AddTransient<IProductsService, ProductsService>();
            services.AddTransient<IColorsService, ColorsService>();
            services.AddTransient<ISizesService, SizesService>();
            services.AddTransient<IGendersService, GendersService>();
            services.AddTransient<IMaterialsService, MaterialsService>();
            services.AddTransient<IProvincesService, ProvincesService>();
            services.AddTransient<ICitiesService, CitiesService>();
            services.AddTransient<IAddressesService, AddressesService>();

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (IServiceScope serviceScope = app.ApplicationServices.CreateScope())
            {
                ApplicationDbContext dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                if (env.IsDevelopment())
                {
                    //dbContext.Database.EnsureDeleted();
                    dbContext.Database.Migrate(); // Apply migration/seed everytime (for development purposes)
                }

                new DatabaseSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "area", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
