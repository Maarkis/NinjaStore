using NinjaStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaStore.Domain.Interfaces.Repositories
{
    public interface IClientRepository : IBaseRepository<Client>
    {
        Client GetClientByEmail(string email);
    }
}
