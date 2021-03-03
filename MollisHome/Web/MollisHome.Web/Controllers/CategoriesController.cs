namespace MollisHome.Web.Controllers
{
    using AutoMapper;

    using MollisHome.Services.Data.Categories;

    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : Controller
    {
        //---------------- FIELDS -----------------
        private readonly IMapper mapper;
        private readonly ICategoriesService categoriesService;

        //------------- CONSTRUCTORS --------------
        public CategoriesController(IMapper mapper, ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
            this.mapper = mapper;
        }

        //-----------------------------------------------------------------------------------------------------//
        //                                           ACTION METHODS                                            //
        //-----------------------------------------------------------------------------------------------------//
        public IActionResult ByName(string name)
        {
            return View();
        }
    }
}
