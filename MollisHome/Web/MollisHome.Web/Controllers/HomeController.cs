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
            //var errMsg = await colorsService.CreateAsync(new Services.DTOs.Colors.ColorDTO
            //{
            //    Name = "Зелен",
            //    HexValue = "#2ba700",
            //});

            //var errMsg2 = await colorsService.CreateAsync(new Services.DTOs.Colors.ColorDTO
            //{
            //    Name = "Зелен",
            //    HexValue = "#2ba700",
            //});

            //var delMsg = await categoriesService.DeleteAsync(1);
            //var test = await productsService.DeleteAsync(1);
            //var test = await colorsService.DeleteAsync(1);

            //var errMsg = await productsService.CreateAsync(new Services.DTOs.Products.ProductDTO
            //{
            //    Name = "Сидни",
            //    Description = "lorem ipsum",
            //    ImgUrl = "",
            //    Category = new CategoryDTO
            //    {
            //        Id = 8,
            //    }
            //});

            //var a = await productsService.CreateAsync(new Services.DTOs.Products.ProductDTO
            //{
            //    Name = "Сидни",
            //    Description = "lorem ipsum",
            //    ImgUrl = "",
            //    Category = new CategoryDTO
            //    {
            //        Id = 8,
            //    }
            //});
            //---------------- Menu categories data ----------------
            var categoryDTOs = this.categoriesService.GetRootCategories();
            var categoryVMs = categoryDTOs.Select(x => mapper.Map<CategoryDTO, CategoryVM>(x)).ToList();
            return this.View(categoryVMs);
        }

        public IActionResult About()
        {
            return this.View();
        }

        public IActionResult Contact()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
