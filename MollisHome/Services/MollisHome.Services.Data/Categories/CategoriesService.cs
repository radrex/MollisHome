namespace MollisHome.Services.Data.Categories
{
    using AutoMapper;

    using MollisHome.Data;
    using MollisHome.Data.Models;

    using MollisHome.Services.Data.Base;
    using MollisHome.Services.DTOs.Categories;

    using System.Linq;
    using System.Collections.Generic;

    public class CategoriesService : BaseService<Category>, ICategoriesService
    {
        //---------------- FIELDS -----------------
        private readonly IMapper mapper;

        //------------- CONSTRUCTORS --------------
        public CategoriesService(IMapper mapper, ApplicationDbContext dbContext) : base(dbContext)
        {
            this.mapper = mapper;
        }

        //--------------- METHODS -----------------
        public IEnumerable<CategoryDTO> GetRootCategories()
        {
            return this.dbSet.ToList().Where(x => x.ParentCategory == null).Select(x => mapper.Map<Category, CategoryDTO>(x)).ToList();
        }

        public CategoryDetailsDTO GetCategoryByName(string name)
        {
            return this.dbSet.Where(x => x.Name == name).Select(x => mapper.Map<Category, CategoryDetailsDTO>(x)).FirstOrDefault();
        }
    }
}
