namespace MollisHome.Web.Areas.Dashboard.Controllers
{
    using AutoMapper;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using MollisHome.Services.Data.Colors;

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

        //----------------------- LISTING FOR COLORS --------------------------


    }
}
