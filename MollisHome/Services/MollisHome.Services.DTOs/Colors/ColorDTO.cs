namespace MollisHome.Services.DTOs.Colors
{
    using MollisHome.Services.DTOs.Base;

    public class ColorDTO : BaseDTO
    {
        public string Name { get; set; }
        public string HexValue { get; set; }
    }
}
