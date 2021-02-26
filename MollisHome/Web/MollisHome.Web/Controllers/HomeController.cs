namespace MollisHome.Web.Controllers
{
    using AutoMapper;

    using MollisHome.Web.Models;
    using MollisHome.Web.ViewModels.Categories;

    using MollisHome.Services.Data.Categories;
    using MollisHome.Services.DTOs.Categories;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    using System;
    using System.Linq;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class HomeController : Controller
    {
        //---------------- FIELDS -----------------
        private readonly IMapper mapper;
        private readonly ICategoriesService categoriesService;

        //------------- CONSTRUCTORS --------------
        public HomeController(IMapper mapper, ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
            this.mapper = mapper;
        }

        //-----------------------------------------------------------------------------------------------------//
        //                                           ACTION METHODS                                            //
        //-----------------------------------------------------------------------------------------------------//
        public IActionResult Index()
        {
            var categoryDTOs = this.categoriesService.GetRootCategories();
            var categoryVMs = categoryDTOs.Select(x => mapper.Map<CategoryDTO, CategoryVM>(x)).ToList();

            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
