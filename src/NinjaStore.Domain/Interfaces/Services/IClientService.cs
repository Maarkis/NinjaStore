using NinjaStore.Domain.DTO;
using NinjaStore.Domain.Entities;
using NinjaStore.Domain.Resources;

namespace NinjaStore.Domain.Interfaces.Services
{
    public interface IClientService : IBaseService<Client>
    {
        ResponseBase CreateClient(CreateClient model);
    }
}
