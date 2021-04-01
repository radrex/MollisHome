namespace MollisHome.Services.DTOs.Provinces
{
    using MollisHome.Services.DTOs.Base;
    using MollisHome.Services.DTOs.Cities;

    using System.Collections.Generic;

    public class ProvinceDTO : BaseDTO
    {
        public string Name { get; set; }
        public IEnumerable<CityDTO> Cities { get; set; }
    }
}
