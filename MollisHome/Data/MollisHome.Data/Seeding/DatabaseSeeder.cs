namespace MollisHome.Data.Seeding
{
    using MollisHome.Data.Models;

    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class DatabaseSeeder : ISeeder
    {
        //---------------- FIELDS -----------------
        private UserManager<ApplicationUser> userManager;
        private RoleManager<IdentityRole> roleManager;

        //------------- CONSTRUCTORS --------------
        public DatabaseSeeder()
        {

        }

        //-------------- PROPERTIES ---------------


        //--------------- METHODS -----------------
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            if (serviceProvider == null)
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
            if (await this.userManager.FindByNameAsync("Admin") == null)
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
        }
    }
}
