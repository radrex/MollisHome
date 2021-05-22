namespace MollisHome.Web.Areas.Dashboard.Controllers
{
    using AutoMapper;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using MollisHome.Services.Data.Colors;

    using System;
    using System.Web;
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
        public async Task<IActionResult> Delete(int id)
        {
            string message = await this.colorsService.DeleteAsync(id);
            this.TempData["ActionMessage"] = message;
            return this.RedirectToAction("Create", "Products");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.PartialView("_Create");
        }
    }
}
