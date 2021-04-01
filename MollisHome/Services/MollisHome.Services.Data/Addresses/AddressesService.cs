namespace MollisHome.Services.Data.Addresses
{
    using AutoMapper;

    using MollisHome.Data;
    using MollisHome.Data.Models;

    using MollisHome.Services.Data.Base;
    using MollisHome.Services.DTOs.Addresses;

    public class AddressesService : BaseService<Address, AddressDTO>, IAddressesService
    {
        //------------- CONSTRUCTORS --------------
        public AddressesService(IMapper mapper, ApplicationDbContext dbContext) : base(mapper, dbContext)
        {

        }

        //--------------- METHODS -----------------

    }
}
