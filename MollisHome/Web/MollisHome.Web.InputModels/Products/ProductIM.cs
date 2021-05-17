namespace MollisHome.Web.InputModels.Products
{
    using Microsoft.AspNetCore.Mvc;

    using MollisHome.Web.ViewModels.Materials;
    using MollisHome.Web.ViewModels.Categories;
    
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ProductIM
    {
        public int Id { get; set; }

        [Display(Name = "Име на продукт")]
        [Remote(action: "VerifyName", controller: "Products")]
        [Required(ErrorMessage = "Моля въведете име на продукт.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Името на продукта трябва да е с дължина от {2} до {1} символа.")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Моля въведете описание на продукта.")]
        [StringLength(450, MinimumLength = 25, ErrorMessage = "Описанието на продукта трябва да е с дължина от {2} до {1} символа.")]
        public string Description { get; set; }

        // TODO: Regex validation
        [Display(Name = "Линк към снимка")]
        [Required(ErrorMessage = "Моля въведете линк към снимка на продукта.")]
        public string ImgUrl { get; set; }

        //--------------- CATEGORY - SINGLE DROPDOWN ---------------
        [Display(Name = "Категория")]
        public int? CategoryId { get; set; }
        public int[] CategoryIds { get; set; }
        public IEnumerable<CategoryVM> Categories { get; set; }

        //-------------- MATERIALS - MULTIPLE DROPDOWN -------------
        [Display(Name = "Материали")]
        public int[] SelectedMaterialIds { get; set; }
        public int[] MaterialIds { get; set; }
        public IEnumerable<MaterialVM> Materials { get; set; }

        //--------------- GENDER, SIZE, COLOR, QUANTITY, DISCOUNT  ----------------
        public int[] ColorId { get; set; }
        public int[] GenderId { get; set; }
        public int[] SizeId { get; set; }
        public int[] Quantity { get; set; }
        public decimal[] Price { get; set; }
        public int[] DiscountPercentage { get; set; }
        public IEnumerable<ProductVariantIM> ProductVariants { get; set; } = new HashSet<ProductVariantIM>(); // Do I even need this ?
    }
}
