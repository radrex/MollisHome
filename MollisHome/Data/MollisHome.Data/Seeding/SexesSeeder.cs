namespace MollisHome.Data.Seeding
{
    using MollisHome.Data.Models;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class SexesSeeder : ISeeder
    {
        //---------------- FIELDS -----------------
        private readonly IReadOnlyCollection<Sex> sexes;

        //------------- CONSTRUCTORS --------------
        public SexesSeeder(List<Sex> sexes)
        {
            this.sexes = sexes.AsReadOnly();
        }

        //--------------- METHODS -----------------
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Sexes.Any())
            {
                return;
            }

            foreach (Sex sex in this.sexes)
            {
                await dbContext.Sexes.AddAsync(new Sex
                {
                    Name = sex.Name,
                });
                await dbContext.SaveChangesAsync(); // Do it on each step to preserve insertion order. :(
            }
        }
    }
}
