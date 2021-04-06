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

        // TODO: Change default "step" message
        [Display(Name = "Количество")]
        [Remote(action: "VerifyQuantity", controller: "Products")]
        [Required(ErrorMessage = "Моля въведете количество за продукта.")]
        [Range(0, 10_000, ErrorMessage = "Количеството не може да бъде по-малко от {1} или по-голямо от {2} бройки.")]
        public int Quantity { get; set; }

        // TODO: Change default "step" message 
        [Display(Name = "Цена")]
        [Remote(action: "VerifyPrice", controller: "Products")]
        [Required(ErrorMessage = "Моля въведете ед.цена на продукта.")]
        [Range(0.50, 10_000, ErrorMessage = "Цената трябва да бъде по-голяма от {1}лв.")]
        public decimal Price { get; set; }

        // TODO: Change default "step" message 
        [Display(Name = "Отстъпка")]
        [Required(ErrorMessage = "Моля въведете отстъпка за продукта.")]
        [Remote(action: "VerifyDiscountPercentage", controller: "Products")]
        [Range(0, 100, ErrorMessage = "Отстъпката трябва да бъде между {1}% и {2}%.")]
        public byte DiscountPercentage { get; set; }

        //--------------- CATEGORY - SINGLE DROPDOWN ---------------
        [Display(Name = "Категория")]
        public int? CategoryId { get; set; }
        public int[] CategoryIds { get; set; }
        public IEnumerable<CategoryVM> Categories { get; set; }

        //-------------- GENDER - SINGLE DROPDOWN ---------------
        [Display(Name = "Тип")]
        public int GenderId { get; set; }
        public int[] GenderIds { get; set; }
        public IEnumerable<GenderVM> Genders { get; set; }

        //--------------- SIZE - SINGLE DROPDOWN ----------------
        [Display(Name = "Размер")]
        public int SizeId { get; set; }
        public int[] SizeIds { get; set; }
        public IEnumerable<SizeVM> Sizes { get; set; }

        //--------------- COLOR - SINGLE DROPDOWN ---------------
        [Display(Name = "Цвят")]
        public int ColorId { get; set; }
        public int[] ColorIds { get; set; }
        public IEnumerable<ColorVM> Colors { get; set; }

        //-------------- MATERIALS - MULTIPLE DROPDOWN -------------
        [Display(Name = "Материали")]
        public int[] MaterialIds { get; set; }
        public IEnumerable<MaterialVM> Materials { get; set; }
    }
}
