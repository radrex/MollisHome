﻿namespace MollisHome.Web.Controllers
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
    using MollisHome.Services.Data.Products;
    using MollisHome.Services.Data.Colors;

    public class HomeController : Controller
    {
        //---------------- FIELDS -----------------
        private readonly IMapper mapper;
        private readonly ICategoriesService categoriesService;
        private readonly IProductsService productsService;
        private readonly IColorsService colorsService;

        //------------- CONSTRUCTORS --------------
        public HomeController(IMapper mapper, ICategoriesService categoriesService, IProductsService productsService, IColorsService colorsService)
        {
            this.categoriesService = categoriesService;
            this.productsService = productsService;
            this.colorsService = colorsService;
            this.mapper = mapper;
        }

        //-----------------------------------------------------------------------------------------------------//
        //                                           ACTION METHODS                                            //
        //-----------------------------------------------------------------------------------------------------//
        public async Task<IActionResult> Index()
        {
            //---------------- Menu categories data ----------------
            var categoryDTOs = this.categoriesService.GetRootCategories();
            var categoryVMs = categoryDTOs.Select(x => mapper.Map<CategoryDTO, CategoryVM>(x)).ToList();
            return this.View(categoryVMs);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
