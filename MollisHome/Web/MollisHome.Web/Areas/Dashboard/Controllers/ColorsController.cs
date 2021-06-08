namespace MollisHome.Web.Areas.Dashboard.Controllers
{
    using AutoMapper;

    using MollisHome.Services.Data.Colors;
    using MollisHome.Services.DTOs.Colors;
    using MollisHome.Web.InputModels.Colors;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using System.Threading.Tasks;

    [Area("Dashboard")]
    [Authorize(Roles = "Admin")]
    public class ColorsController : Controller
    {
        //---------------- FIELDS -----------------
        private readonly IMapper mapper;
        private readonly IColorsService colorsService;

        //------------- CONSTRUCTORS --------------
        public ColorsController(IMapper mapper, IColorsService colorsService)
        {
            this.mapper = mapper;
            this.colorsService = colorsService;
        }

        //-----------------------------------------------------------------------------------------------------//
        //                                           ACTION METHODS                                            //
        //-----------------------------------------------------------------------------------------------------//

        [HttpPost]
        public async Task<IActionResult> Create(ColorIM color)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Create", "Products"); // have to redirect and then open the modal with new colors or smth
            }

            ColorDTO colorDTO = new ColorDTO
            {
                Name = color.Name,
                HexValue = color.HexValue,
            };

            string message = await this.colorsService.CreateAsync(colorDTO);
            this.TempData["ActionMessage"] = message;
            return this.RedirectToAction("Create", "Products");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            string message = await this.colorsService.DeleteAsync(id);
            this.TempData["ActionMessage"] = message;
            return this.RedirectToAction("Create", "Products");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ColorIM color)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Create", "Products"); // have to redirect and then open the modal with new colors or smth
            }

            ColorDTO colorDTO = new ColorDTO
            {
                Id = color.Id,
                Name = color.Name,
                HexValue = color.HexValue,
            };

            string message = await this.colorsService.EditAsync(colorDTO);
            this.TempData["ActionMessage"] = message;
            return this.RedirectToAction("Create", "Products"); // have to redirect and then open the modal with new colors or smth
        }

        //----------------------- VALIDATIONS --------------------------
        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyName(string name)
        {
            if (this.colorsService.GetByName(name) != null) // TODO: Add exists method with overloads for different props
            {
                return this.Json($"Цвят с името '{name}' вече съществува.");
            }

            return this.Json(true);
        }
    }
}
