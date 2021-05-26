namespace MollisHome.Web.InputModels.Colors
{
    using MollisHome.Web.ViewModels.Colors;
    
    using Microsoft.AspNetCore.Mvc;

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ColorIM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Моля въведете цвят.")]
        [Remote(action: "VerifyName", controller: "Colors")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Името на цвета трябва да е с дължина от {2} до {1} символа.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Моля въведете стойност на цвета.")]
        [RegularExpression(@"^#(?:[0-9a-fA-F]{3}){1,2}$", ErrorMessage = "Стойността на цвета трябва да е във валиден HEX формат.")]
        public string HexValue { get; set; }

        //--------------- COLORS - TABLE ---------------
        public IEnumerable<ColorVM> Colors { get; set; }
    }
}
