namespace MollisHome.Web.Areas.Dashboard.Controllers
{
    using MollisHome.Services.Data.Products;
    using MollisHome.Web.InputModels.Products;
    using MollisHome.Web.ViewModels.Categories;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using System.Threading.Tasks;
    using MollisHome.Services.DTOs.Products;
    using MollisHome.Services.DTOs.Categories;
    using MollisHome.Services.Data.Categories;

    using System.Linq;
    using AutoMapper;

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

        //------------- CONSTRUCTORS --------------
        public ProductsController(IMapper mapper, IProductsService productsService, ICategoriesService categoriesService)
        {
            this.mapper = mapper;
            this.productsService = productsService;
            this.categoriesService = categoriesService;
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
            var categoryDTOs = this.categoriesService.GetAll(); // TODO: Extract method to get only the lastNode Categories, or make a recursive select when choosing a category for the product
            var categoryVMs = categoryDTOs.Select(x => mapper.Map<CategoryDTO, CategoryVM>(x)).ToList();
            int[] categoryIds = categoryDTOs.Select(x => x.Id).ToArray();

            ProductIM productIM = new ProductIM
            {
                Categories = categoryVMs,
                CategoryIds = categoryIds,
            };

            return this.View(productIM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductIM product)
        {
            //TODO: validate form
            ProductDTO productDTO = new ProductDTO
            {
                Name = product.Name,
                Description = product.Description,
                ImgUrl = product.ImgUrl,
                CategoryId = product.CategoryId,
            };

            string message = await this.productsService.CreateAsync(productDTO);
            this.TempData["ActionMessage"] = message;
            return this.RedirectToAction("Create");
        }
    }
}
