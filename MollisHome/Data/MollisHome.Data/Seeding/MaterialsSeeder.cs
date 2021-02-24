namespace MollisHome.Data.Seeding
{
    using MollisHome.Data.Models;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class MaterialsSeeder : ISeeder
    {
        //---------------- FIELDS -----------------
        private readonly IReadOnlyCollection<Material> materials;

        //------------- CONSTRUCTORS --------------
        public MaterialsSeeder(List<Material> materials)
        {
            this.materials = materials.AsReadOnly();
        }

        //--------------- METHODS -----------------
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Materials.Any())
            {
                return;
            }

            foreach (Material material in this.materials)
            {
                await dbContext.Materials.AddAsync(new Material
                {
                    Name = material.Name,
                    Percentage = material.Percentage,
                });
                await dbContext.SaveChangesAsync(); // Do it on each step to preserve insertion order. :(
            }
        }
    }
}
