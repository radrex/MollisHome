﻿namespace MollisHome.Web.Areas.Dashboard.Controllers
{
    using AutoMapper;
    
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using System;
    using System.Web;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    
    using MollisHome.Web.ViewModels.Sizes;
    using MollisHome.Web.ViewModels.Colors;
    using MollisHome.Web.ViewModels.Genders;
    using MollisHome.Web.ViewModels.Products;
    using MollisHome.Web.ViewModels.Materials;
    using MollisHome.Web.InputModels.Products;
    using MollisHome.Web.ViewModels.Categories;

    using MollisHome.Services.Data.Sizes;
    using MollisHome.Services.Data.Colors;
    using MollisHome.Services.Data.Genders;
    using MollisHome.Services.Data.Products;
    using MollisHome.Services.Data.Materials;
    using MollisHome.Services.Data.Categories;

    using MollisHome.Services.DTOs.Stock;
    using MollisHome.Services.DTOs.Sizes;
    using MollisHome.Services.DTOs.Colors;
    using MollisHome.Services.DTOs.Genders;
    using MollisHome.Services.DTOs.Products;
    using MollisHome.Services.DTOs.Materials;
    using MollisHome.Services.DTOs.Categories;

    [Area("Dashboard")]
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        //-------------- CONSTANTS ----------------
        private const int ItemsPerPage = 6;
        
        //---------------- FIELDS -----------------
        private readonly IMapper mapper;
        private readonly IProductsService productsService;
        private readonly ICategoriesService categoriesService;
        private readonly IMaterialsService materialsService;
        private readonly IColorsService colorsService;
        private readonly IGendersService gendersService;
        private readonly ISizesService sizesService;

        //------------- CONSTRUCTORS --------------
        public ProductsController(IMapper mapper, IProductsService productsService, ICategoriesService categoriesService, 
                                  IMaterialsService materialsService, IColorsService colorsService, IGendersService gendersService,
                                  ISizesService sizesService)
        {
            this.mapper = mapper;
            this.productsService = productsService;
            this.categoriesService = categoriesService;
            this.materialsService = materialsService;
            this.colorsService = colorsService;
            this.gendersService = gendersService;
            this.sizesService = sizesService;
        }

        //-----------------------------------------------------------------------------------------------------//
        //                                           ACTION METHODS                                            //
        //-----------------------------------------------------------------------------------------------------//

        [HttpGet]
        public IActionResult All(int page = 1)
        {
            IEnumerable<ProductDTO> productDTOs = this.productsService.GetAll(ItemsPerPage, (page - 1) * ItemsPerPage);
            ProductListVM products = new ProductListVM()
            {
                Products = productDTOs.Select(x => this.mapper.Map<ProductDTO, ProductVM>(x)).ToList(),
                PagesCount = (int)Math.Ceiling((double)this.productsService.Count() / ItemsPerPage),
            };

            if (products.PagesCount == 0)
            {
                products.PagesCount = 1;
            }

            products.CurrentPage = page;
            return this.View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<CategoryDTO> categoryDTOs = this.categoriesService.GetAll(); // TODO: Extract method to get only the lastNode Categories, or make a recursive select when choosing a category for the product
            IEnumerable<MaterialDTO> materialDTOs = this.materialsService.GetAll();
            IEnumerable<ColorDTO> colorDTOs = this.colorsService.GetAll();
            IEnumerable<GenderDTO> genderDTOs = this.gendersService.GetAll();
            IEnumerable<SizeDTO> sizeDTOs = this.sizesService.GetAll();

            ProductIM productIM = new ProductIM
            {
                Categories = categoryDTOs.Select(x => mapper.Map<CategoryDTO, CategoryVM>(x)).ToList(),
                CategoryIds = categoryDTOs.Select(x => x.Id).ToArray(),

                Materials = materialDTOs.Select(x => mapper.Map<MaterialDTO, MaterialVM>(x)).ToList(),
                MaterialIds = materialDTOs.Select(x => x.Id).ToArray(),

                Colors = colorDTOs.Select(x => mapper.Map<ColorDTO, ColorVM>(x)).ToList(),
                Genders = genderDTOs.Select(x => mapper.Map<GenderDTO, GenderVM>(x)).ToList(),
                Sizes = sizeDTOs.Select(x => mapper.Map<SizeDTO, SizeVM>(x)).ToList(),
            };

            return this.View(productIM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductIM product)
        {
            // TODO: Validation not working on nested IM, also check for duplicity
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Create");
            }

            // TODO: Get collection of input models instead of array of Ids and values if possible
            List<StockDTO> stock = new List<StockDTO>();
            for (int i = 0; i < product.ColorId.Length; i++)
            {
                stock.Add(new StockDTO
                {
                    ColorId = product.ColorId[i],
                    GenderId = product.GenderId[i],
                    SizeId = product.SizeId[i],
                    Quantity = product.Quantity[i],
                    Price = product.Price[i],
                    DiscountPercentage = (byte)product.DiscountPercentage[i]
                });
            }

            ProductDTO productDTO = new ProductDTO
            {
                Name = product.Name,
                Description = product.Description,
                ImgUrl = product.ImgUrl,
                CategoryId = product.CategoryId,
                MaterialIds = product.MaterialIds,
                Stock = stock,
            };

            string message = await this.productsService.CreateAsync(productDTO);
            this.TempData["ActionMessage"] = message;
            return this.RedirectToAction("Create");
        }

        [HttpGet]
        public IActionResult CreateVariant()
        {
            IEnumerable<ColorDTO> colorDTOs = this.colorsService.GetAll();
            IEnumerable<GenderDTO> genderDTOs = this.gendersService.GetAll();
            IEnumerable<SizeDTO> sizeDTOs = this.sizesService.GetAll();

            return this.PartialView("_CreateVariant", new ProductVariantIM()
            {
                ColorIds = colorDTOs.Select(x => x.Id).ToArray(),
                Colors = colorDTOs.Select(x => mapper.Map<ColorDTO, ColorVM>(x)).ToList(),

                GenderIds = genderDTOs.Select(x => x.Id).ToArray(),
                Genders = genderDTOs.Select(x => mapper.Map<GenderDTO, GenderVM>(x)).ToList(),

                SizeIds = sizeDTOs.Select(x => x.Id).ToArray(),
                Sizes = sizeDTOs.Select(x => mapper.Map<SizeDTO, SizeVM>(x)).ToList(),
            });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            IEnumerable<CategoryDTO> categoryDTOs = this.categoriesService.GetAll(); // TODO: Extract method to get only the lastNode Categories, or make a recursive select when choosing a category for the product
            IEnumerable<MaterialDTO> materialDTOs = this.materialsService.GetAll();
            IEnumerable<ColorDTO> colorDTOs = this.colorsService.GetAll();
            IEnumerable<GenderDTO> genderDTOs = this.gendersService.GetAll();
            IEnumerable<SizeDTO> sizeDTOs = this.sizesService.GetAll();

            ProductDTO productDTO = this.productsService.GetById(id);

            List<ProductVariantIM> productVariants = new List<ProductVariantIM>();
            foreach (var prodVariant in productDTO.Stock)
            {
                productVariants.Add(new ProductVariantIM()
                {
                    ColorId = prodVariant.Color.Id,
                    ColorIds = colorDTOs.Select(x => x.Id).ToArray(),
                    Colors = colorDTOs.Select(x => mapper.Map<ColorDTO, ColorVM>(x)).ToList(),

                    GenderId = prodVariant.Gender.Id,
                    GenderIds = genderDTOs.Select(x => x.Id).ToArray(),
                    Genders = genderDTOs.Select(x => mapper.Map<GenderDTO, GenderVM>(x)).ToList(),

                    SizeId = prodVariant.Size.Id,
                    SizeIds = sizeDTOs.Select(x => x.Id).ToArray(),
                    Sizes = sizeDTOs.Select(x => mapper.Map<SizeDTO, SizeVM>(x)).ToList(),

                    Quantity = prodVariant.Quantity,
                    Price = prodVariant.Price,
                    DiscountPercentage = prodVariant.DiscountPercentage,
                });
            }
            
            ProductIM productIM = new ProductIM
            {
                Id = productDTO.Id,
                Name = productDTO.Name,
                Description = productDTO.Description,
                ImgUrl = productDTO.ImgUrl,

                CategoryId = productDTO.CategoryId,
                Categories = categoryDTOs.Select(x => mapper.Map<CategoryDTO, CategoryVM>(x)).ToList(),
                CategoryIds = categoryDTOs.Select(x => x.Id).ToArray(),

                SelectedMaterialIds = productDTO.Materials.Select(x => x.Material.Id).ToArray(),
                Materials = materialDTOs.Select(x => mapper.Map<MaterialDTO, MaterialVM>(x)).ToList(),
                MaterialIds = materialDTOs.Select(x => x.Id).ToArray(),

                //ProductVariants = productVariants,
            };

            return this.View(productIM);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ProductIM product)
        {
            if (!this.productsService.Exists(product.Id))
            {
                return this.BadRequest();
            }

            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Edit" , new { id = product.Id });
            }

            ProductDTO productDTO = new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                ImgUrl = product.ImgUrl,
                CategoryId = product.CategoryId,
                MaterialIds = product.MaterialIds,

                //ColorId = product.ProductVariants.Select(x => x.ColorId).FirstOrDefault(),
                //GenderId = product.ProductVariants.Select(x => x.GenderId).FirstOrDefault(),
                //SizeId = product.ProductVariants.Select(x => x.SizeId).FirstOrDefault(),
                //Quantity = product.ProductVariants.Select(x => x.Quantity).FirstOrDefault(),
                //Price = product.ProductVariants.Select(x => x.Price).FirstOrDefault(),
                //DiscountPercentage = product.ProductVariants.Select(x => x.DiscountPercentage).FirstOrDefault(),
            };

            await this.productsService.EditAsync(productDTO);
            // TODO: Add Message for deletion
            return this.RedirectToAction("Edit", new { id = product.Id }); 
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            // Logic for page modifier after Delete. Redirect on same page if it still has items. Redirect to previous page if no items left on the deleted item page.
            Uri uri = new Uri(Request.Headers["Referer"].ToString());
            bool hasPage = int.TryParse(HttpUtility.ParseQueryString(uri.Query).Get("page"), out int page);

            int productsCount = this.productsService.Count();
            if (hasPage && productsCount % ItemsPerPage == 1)
            {
                page--;
            }

            string message = await this.productsService.DeleteAsync(id);
            this.TempData["ActionMessage"] = message;
            return this.RedirectToAction("All", new { page = page });
        }

        //----------------------- VALIDATIONS --------------------------
        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyName(string name)
        {
            if (this.productsService.GetByName(name) != null) // TODO: Add exists method with overloads for different props
            {
                return this.Json($"Продукт с името '{name}' вече съществува.");
            }

            return this.Json(true);
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyDiscountPercentage(byte discountPercentage)
        {
            // TODO: should i check the constraint from the db or do it manually ?
            if (discountPercentage < 0 || discountPercentage > 100)
            {
                return this.Json($"Отстъпката трябва да бъде между 0% и 100%.");
            }

            return this.Json(true);
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyPrice(decimal price)
        {
            // TODO: should i check the constraint from the db or do it manually ?
            if (price < 0)
            {
                return this.Json($"Цената трябва да бъде по-голяма от 0.50лв.");
            }

            return this.Json(true);
        }

        public IActionResult VerifyQuantity(int quantity)
        {
            // TODO: should i check the constraint from the db or do it manually ?
            if (quantity < 0)
            {
                return this.Json($"Количеството не трябва да бъде по-малко от 0.");
            }
            return this.Json(true);
        }
    }
}
