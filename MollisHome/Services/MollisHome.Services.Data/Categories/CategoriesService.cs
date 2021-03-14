namespace MollisHome.Services.Data.Categories
{
    using AutoMapper;

    using MollisHome.Data;
    using MollisHome.Data.Models;

    using MollisHome.Services.Data.Base;
    using MollisHome.Services.DTOs.Categories;

    using System.Linq;
    using System.Collections.Generic;

    public class CategoriesService : BaseService<Category, CategoryDTO>, ICategoriesService
    {
        //------------- CONSTRUCTORS --------------
        public CategoriesService(IMapper mapper, ApplicationDbContext dbContext) : base(mapper, dbContext)
        {

        }

        //--------------- METHODS -----------------
        public bool HasProducts(int categoryId)
        {
            return this.HasEntities() && this.dbSet.First(x => x.Id == categoryId).Products.Any();
        }

        public bool HasProducts(string categoryName)
        {
            return this.HasEntities() && this.dbSet.First(x => x.Name == categoryName).Products.Any();
        }

        public bool HasParentCategory(int categoryId)
        {
            return this.dbSet.Any(x => x.Id == categoryId && x.ParentCategory != null);
        }

        public bool HasParentCategory(string categoryName)
        {
            return this.dbSet.Any(x => x.Name == categoryName && x.ParentCategory != null);
        }

        public CategoryDTO GetByName(string categoryName)
        {
            return this.mapper.Map<Category, CategoryDTO>(this.dbSet.FirstOrDefault(x => x.Name == categoryName));
        }

        public CategoryDTO GetParentCategory(int categoryId)
        {
            return this.mapper.Map<Category, CategoryDTO>(this.dbSet.FirstOrDefault(x => x.Id == categoryId).ParentCategory);
        }
        public CategoryDTO GetParentCategory(string categoryName)
        {
            return this.mapper.Map<Category, CategoryDTO>(this.dbSet.FirstOrDefault(x => x.Name == categoryName).ParentCategory);
        }

        public IEnumerable<CategoryDTO> GetRootCategories()
        {
            return this.dbSet.Where(x => x.ParentCategory == null).Select(x => this.mapper.Map<Category, CategoryDTO>(x)).ToList();
        }
    }
}
