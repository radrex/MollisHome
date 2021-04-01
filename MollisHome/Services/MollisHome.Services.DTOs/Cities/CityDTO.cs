namespace MollisHome.Services.DTOs.Cities
{
    using MollisHome.Services.DTOs.Base;
    using MollisHome.Services.DTOs.Provinces;
    using MollisHome.Services.DTOs.Addresses;

    using System.Collections.Generic;

    public class CityDTO : BaseDTO
    {
        public string Name { get; set; }
        public string PostCode { get; set; }
        public ProvinceDTO Province { get; set; }
        public IEnumerable<AddressDTO> Addresses { get; set; }
    }
}
