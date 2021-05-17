using NinjaStore.Domain.DTO;
using NinjaStore.Domain.Entities;
using NinjaStore.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaStore.Domain.Interfaces.Services
{
    public interface IAddressService : IBaseService<Address>
    {        
        ResponseBase ValidateAddAddress(List<CreateAddress> addresses);
    }
}
