using NinjaStore.Domain.BaseEntity;
using NinjaStore.Domain.Validators;
using System.Collections.Generic;

namespace NinjaStore.Domain.Entities
{
    public class Client : BaseEntityByGuid
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public virtual List<Address> Addresses { get; private set; }
        public virtual List<Order> Orders { get; private set; }

        public Client(string name, string email, List<Address> addresses)
        {          

            Name = name;
            Email = email;
            Addresses = addresses;

            Validate(this, new ClientValidator());
        }
    }
}
