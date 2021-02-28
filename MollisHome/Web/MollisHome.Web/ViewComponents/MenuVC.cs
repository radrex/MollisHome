namespace MollisHome.Web.ViewComponents
{
    using AutoMapper;

    using MollisHome.Services.Data.Categories;
    using MollisHome.Services.DTOs.Categories;

    using MollisHome.Web.ViewModels.Categories;

    using Microsoft.AspNetCore.Mvc;

    using System.Linq;

    public class MenuVC : ViewComponent
    {
        //--------------- FIELDS ------------------
        private readonly ICategoriesService categoriesService;
        private readonly IMapper mapper;

        //------------- CONSTRUCTORS --------------
        public MenuVC(IMapper mapper, ICategoriesService categoriesService)
        {
            this.mapper = mapper;
            this.categoriesService = categoriesService;
        }

        //--------------- METHODS -----------------
        public IViewComponentResult Invoke()
        {
            var categoryDTOs = this.categoriesService.GetRootCategories();
            var categoryVMs = categoryDTOs.Select(x => mapper.Map<CategoryDTO, CategoryVM>(x)).ToList();
            return this.View(categoryVMs);
        }
    }
}
