namespace MollisHome.Data.Seeding
{
    using MollisHome.Data.Models;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class SizesSeeder : ISeeder
    {
        //---------------- FIELDS -----------------
        private readonly IReadOnlyCollection<Size> sizes;

        //------------- CONSTRUCTORS --------------
        public SizesSeeder(List<Size> sizes)
        {
            this.sizes = sizes.AsReadOnly();
        }

        //--------------- METHODS -----------------
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Sizes.Any())
            {
                return;
            }

            foreach (Size size in this.sizes)
            {
                await dbContext.Sizes.AddAsync(new Size
                {
                    Name = size.Name,
                });
                await dbContext.SaveChangesAsync(); // Do it on each step to preserve insertion order. :(
            }
        }
    }
}
