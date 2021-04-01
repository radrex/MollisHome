namespace MollisHome.Services.DTOs.Addresses
{
    using MollisHome.Services.DTOs.Base;
    using MollisHome.Services.DTOs.Cities;

    public class AddressDTO : BaseDTO
    {
        public string Name { get; set; }
        public bool IsCourierAddress { get; set; }
        public CityDTO City { get; set; }

        // TODO: uncomment when done with redesigning the orders
        //public IEnumerable<OrderDTO> Orders { get; set; }
    }
}
