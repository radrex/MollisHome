namespace MollisHome.Services.DTOs.Materials
{
    using MollisHome.Services.DTOs.Base;

    public class MaterialDTO : BaseDTO
    {
        public string Name { get; set; }
        public int? Percentage { get; set; }
    }
}
