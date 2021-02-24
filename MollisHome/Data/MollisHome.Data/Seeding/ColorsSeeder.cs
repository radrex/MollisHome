namespace MollisHome.Data.Seeding
{
    using MollisHome.Data.Models;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class ColorsSeeder : ISeeder
    {
        //---------------- FIELDS -----------------
        private readonly IReadOnlyCollection<Color> colors;

        //------------- CONSTRUCTORS --------------
        public ColorsSeeder(List<Color> colors)
        {
            this.colors = colors.AsReadOnly();
        }

        //--------------- METHODS -----------------
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Colors.Any())
            {
                return;
            }

            foreach (Color color in this.colors)
            {
                await dbContext.Colors.AddAsync(new Color
                {
                    Name = color.Name,
                    HexValue = color.HexValue,
                });
                await dbContext.SaveChangesAsync(); // Do it on each step to preserve insertion order. :(
            }
        }
    }
}
