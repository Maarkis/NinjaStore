using NinjaStore.Domain.DTO;
using NinjaStore.Domain.Entities;
using NinjaStore.Domain.Interfaces.Repositories;
using NinjaStore.Domain.Interfaces.Services;
using NinjaStore.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaStore.Service.Services
{

    public class AddressService : BaseService<Address>, IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository) : base(addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public ResponseBase ValidateAddAddress(List<CreateAddress> addressesModel)
        {
            ResponseBase responseBase = new ResponseBase { Success = true };
            List<Address> addresses = new List<Address>();
            addressesModel.ForEach(address => {
                Address newAddress = new Address(address.Name, address.Cep, address.Complement, address.District, address.City, address.State, address.Number);
                if (newAddress.Invalid)
                {
                    responseBase.Success = false;
                }
                addresses.Add(newAddress);
            });

            responseBase.Result = addresses;

            return responseBase;
        }
    }
}
