namespace MollisHome.Services.Data.Categories
{
    using AutoMapper;

    using MollisHome.Data;
    using MollisHome.Data.Models;
    using MollisHome.Services.DTOs.Categories;

    using System.Linq;
    using System.Collections.Generic;

    public class CategoriesService : ICategoriesService
    {
        //---------------- FIELDS -----------------
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        //------------- CONSTRUCTORS --------------
        public CategoriesService(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        //--------------- METHODS -----------------
        public IEnumerable<CategoryDTO> GetRootCategories()
        {
            return this.dbContext.Categories.Where(x => x.ParentCategory == null).Select(x => mapper.Map<Category, CategoryDTO>(x)).ToList();
        }
    }
}
