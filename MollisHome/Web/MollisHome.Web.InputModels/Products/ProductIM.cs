namespace MollisHome.Web.InputModels.Products
{
    using Microsoft.AspNetCore.Mvc;

    using MollisHome.Web.ViewModels.Sizes;
    using MollisHome.Web.ViewModels.Colors;
    using MollisHome.Web.ViewModels.Genders;
    using MollisHome.Web.ViewModels.Materials;
    using MollisHome.Web.ViewModels.Categories;
    
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ProductIM
    {
        public int Id { get; set; }

        [Required]
        [Remote(action: "VerifyName", controller: "Products")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Името на продукта трябва да е с дължина от {2} до {1} символа.")]
        public string Name { get; set; }

        [Required]
        [StringLength(450, MinimumLength = 25, ErrorMessage = "Описанието на продукта трябва да е с дължина от {2} до {1} символа.")]
        public string Description { get; set; }
        
        [Required]
        // TODO: Regex validation
        public string ImgUrl { get; set; }

        //--------------- COLOR - SINGLE DROPDOWN ---------------
        public int ColorId { get; set; }
        public IEnumerable<ColorVM> Colors { get; set; }

        //-------------- GENDER - SINGLE DROPDOWN ---------------
        public int GenderId { get; set; }
        public IEnumerable<GenderVM> Genders { get; set; }

        //--------------- SIZE - SINGLE DROPDOWN ----------------
        public int SizeId { get; set; }
        public IEnumerable<SizeVM> Sizes { get; set; }

        //-------------- MATERIALS - MULTIPLE DROPDOWN -------------
        public int[] MaterialIds { get; set; }
        public IEnumerable<MaterialVM> Materials { get; set; }

        //--------------- CATEGORY - SINGLE DROPDOWN ---------------
        public int? CategoryId { get; set; }
        public int[] CategoryIds { get; set; }
        public IEnumerable<CategoryVM> Categories { get; set; }
    }
}
