using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NinjaStore.Domain.Entities;
using NinjaStore.Domain.Interfaces.Repositories;
using NinjaStore.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NinjaStore.Infrastructure.Data.Repository
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        private DbSet<Client> _clients;

        public ClientRepository(DatabaseContext context, IConfiguration _configuration) : base(context, _configuration)
        {
            _clients = context.Clients;
        }

        public Client GetClientByEmail(string email)
        {
            return _clients.Where(x => x.Email == email).Include(x => x.Addresses).FirstOrDefault();
        }
    }
}
