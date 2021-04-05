namespace MollisHome.Web.Areas.Dashboard.Controllers
{
    using AutoMapper;
    
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    
    using MollisHome.Web.InputModels.Products;
    using MollisHome.Web.ViewModels.Categories;
    
    using MollisHome.Services.Data.Products;
    using MollisHome.Services.Data.Materials;
    using MollisHome.Services.Data.Categories;

    using MollisHome.Services.DTOs.Products;
    using MollisHome.Services.DTOs.Materials;
    using MollisHome.Services.DTOs.Categories;
    using MollisHome.Web.ViewModels.Materials;

    [Area("Dashboard")]
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        //-------------- CONSTANTS ----------------
        private const int ItemsPerPage = 10;
        
        //---------------- FIELDS -----------------
        private readonly IMapper mapper;
        private readonly IProductsService productsService;
        private readonly ICategoriesService categoriesService;
        private readonly IMaterialsService materialsService;

        //------------- CONSTRUCTORS --------------
        public ProductsController(IMapper mapper, IProductsService productsService, ICategoriesService categoriesService, IMaterialsService materialsService)
        {
            this.mapper = mapper;
            this.productsService = productsService;
            this.categoriesService = categoriesService;
            this.materialsService = materialsService;
        }

        //-----------------------------------------------------------------------------------------------------//
        //                                           ACTION METHODS                                            //
        //-----------------------------------------------------------------------------------------------------//

        //----------------------- LISTING FOR PRODUCTS --------------------------
        [HttpGet]
        public IActionResult All()
        {
            //var products = this.productsService.GetAll();
            return this.View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<CategoryDTO> categoryDTOs = this.categoriesService.GetAll(); // TODO: Extract method to get only the lastNode Categories, or make a recursive select when choosing a category for the product
            List<CategoryVM> categoryVMs = categoryDTOs.Select(x => mapper.Map<CategoryDTO, CategoryVM>(x)).ToList();
            int[] categoryIds = categoryDTOs.Select(x => x.Id).ToArray();

            IEnumerable<MaterialDTO> materialDTOs = this.materialsService.GetAll();
            List<MaterialVM> materialVMs = materialDTOs.Select(x => mapper.Map<MaterialDTO, MaterialVM>(x)).ToList();
            int[] materialIds = materialDTOs.Select(x => x.Id).ToArray();

            ProductIM productIM = new ProductIM
            {
                Categories = categoryVMs,
                CategoryIds = categoryIds,
                Materials = materialVMs,
                MaterialIds = materialIds,
            };

            return this.View(productIM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductIM product)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Create");
            }

            ProductDTO productDTO = new ProductDTO
            {
                Name = product.Name,
                Description = product.Description,
                ImgUrl = product.ImgUrl,
                CategoryId = product.CategoryId,
                MaterialIds = product.MaterialIds,
            };

            string message = await this.productsService.CreateAsync(productDTO);
            this.TempData["ActionMessage"] = message;
            return this.RedirectToAction("Create");
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyName(string name)
        {
            if (this.productsService.GetByName(name) != null) // TODO: Add exists method with overloads for different props
            {
                return this.Json($"Продукт с името '{name}' вече съществува.");
            }

            return this.Json(true);
        }
    }
}
