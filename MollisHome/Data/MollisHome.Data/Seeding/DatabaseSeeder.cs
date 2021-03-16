namespace MollisHome.Data.Seeding
{
    using MollisHome.Data.Utils;
    using MollisHome.Data.Models;

    using Newtonsoft.Json;

    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class DatabaseSeeder : ISeeder
    {
        //---------------- FIELDS -----------------
        private readonly string path = string.Empty;
        private readonly JSONData jsonData;
        private readonly IReadOnlyCollection<ISeeder> seeders;

        private UserManager<ApplicationUser> userManager;
        private RoleManager<IdentityRole> roleManager;

        //------------- CONSTRUCTORS --------------
        public DatabaseSeeder()
        {
            UriBuilder uri = new UriBuilder(FileUtils.GetSolutionDir());
            this.path = Uri.UnescapeDataString(uri.Path) + "/Data/MollisHome.Data/Seeding/seed.json";

            this.jsonData = JsonConvert.DeserializeObject<JSONData>(File.ReadAllText(this.path));
            this.seeders = new List<ISeeder> { 
                new GendersSeeder(this.jsonData.Genders),
                new SizesSeeder(this.jsonData.Sizes),
                new MaterialsSeeder(this.jsonData.Materials),
                new ColorsSeeder(this.jsonData.Colors),
                new CategoriesSeeder(this.jsonData.Categories),
                new ProductsSeeder(this.jsonData.Products),
            }.AsReadOnly();
        }

        //--------------- METHODS -----------------
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext is null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            if (serviceProvider is null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            //---------------------- SET MANAGERS ----------------------
            this.userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            this.roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            //---------------------- SEED ROLES ----------------------
            string[] roles = { "Admin", "User", "Guest" };
            foreach (string role in roles)
            {
                if (await this.roleManager.FindByNameAsync(role) == null)
                {
                    await this.roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            //---------------------- SEED ADMIN USER ----------------------
            if (await this.userManager.FindByNameAsync("Admin") is null)
            {
                ApplicationUser admin = new ApplicationUser("admin@gmail.com", "Admin");
                IdentityResult result = await this.userManager.CreateAsync(admin, "123456"); //TODO: change hardcoded email and password with secret ones
                if (result.Succeeded)
                {
                    await this.userManager.AddToRoleAsync(admin, "Admin");
                }
                else
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }

            //---------------------- SEED DATA ----------------------
            foreach (ISeeder seeder in this.seeders)
            {
                await seeder.SeedAsync(dbContext, serviceProvider);
            }
        }
    }
}
