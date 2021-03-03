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
        public IEnumerable<CategoryDTO> GetRootCategories()
        {
            return this.dbSet.Where(x => x.ParentCategory == null).Select(x => mapper.Map<Category, CategoryDTO>(x)).ToList();
        }
    }
}
