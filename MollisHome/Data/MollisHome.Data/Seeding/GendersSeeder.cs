namespace MollisHome.Data.Seeding
{
    using MollisHome.Data.Models;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class GendersSeeder : ISeeder
    {
        //---------------- FIELDS -----------------
        private readonly IReadOnlyCollection<Gender> genders;

        //------------- CONSTRUCTORS --------------
        public GendersSeeder(List<Gender> genders)
        {
            this.genders = genders.AsReadOnly();
        }

        //--------------- METHODS -----------------
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Genders.Any())
            {
                return;
            }

            foreach (Gender gender in this.genders)
            {
                await dbContext.Genders.AddAsync(new Gender
                {
                    Name = gender.Name,
                });
                await dbContext.SaveChangesAsync(); // Do it on each step to preserve insertion order. :(
            }
        }
    }
}
