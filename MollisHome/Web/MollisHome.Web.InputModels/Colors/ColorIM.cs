namespace MollisHome.Web.InputModels.Colors
{
    using System.ComponentModel.DataAnnotations;

    public class ColorIM
    {
        public int Id { get; set; }

        // TODO: VALIDATION PLEASE

        [Required(ErrorMessage = "Моля въведете цвят.")]
        public string Name { get; set; }
        public string HexValue { get; set; }
    }
}
