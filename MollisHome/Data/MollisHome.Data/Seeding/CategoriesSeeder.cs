namespace MollisHome.Data.Seeding
{
    using MollisHome.Data.Models;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class CategoriesSeeder : ISeeder
    {
        //---------------- FIELDS -----------------
        private readonly IReadOnlyCollection<Category> categories;

        //------------- CONSTRUCTORS --------------
        public CategoriesSeeder(List<Category> categories)
        {
            this.categories = categories.AsReadOnly();
        }

        //--------------- METHODS -----------------
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            foreach (Category category in this.categories)
            {
                await dbContext.Categories.AddAsync(new Category
                {
                    Name = category.Name,
                    Description = category.Description,
                    ImgUrl = category.ImgUrl,
                    ParentCategoryId = category.ParentCategoryId,
                    IsLastNode = category.IsLastNode,
                });
                await dbContext.SaveChangesAsync(); // Do it on each step to preserve insertion order. :(
            }
        }
    }
}
