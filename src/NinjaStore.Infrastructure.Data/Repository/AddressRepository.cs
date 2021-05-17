using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NinjaStore.Domain.Entities;
using NinjaStore.Domain.Interfaces.Repositories;
using NinjaStore.Infrastructure.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace NinjaStore.Infrastructure.Data.Repository
{
    public class LocationRepository : BaseRepository<Address>, IAddressRepository
    {
        private DbSet<Address> _address;
        public LocationRepository(DatabaseContext context, IConfiguration configuration) : base(context, configuration)
        {
            _address = context.Addresses;
        }

        public List<Address> GetAddressesByClientId(int clientId)
        {
            return _address.Where(x => x.ClientId == clientId).ToList();
        }
    }
}
