using FluentValidation;
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
    public class ClientService : BaseService<Client>, IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IAddressService _addressService;

        public ClientService(IClientRepository clientRepository, IAddressService addressService) : base(clientRepository)
        {
            _clientRepository = clientRepository;
            _addressService = addressService;
        }

        public ResponseBase CreateClient(CreateClient model)
        {
            ResponseBase responseBase = new ResponseBase();
            try
            {
                if(model.Address != null)
                {
                    ResponseBase addressResponse = _addressService.ValidateAddAddress(model.Address);
                    if(!addressResponse.Success)
                    {
                        addressResponse.Message = "Endereço Inválidos";                        

                        return addressResponse;
                    }
                    
                    Client newClient = new Client(model.Name, model.Email, addressResponse.Result as List<Address>);
                    if(newClient.Invalid)
                    {
                        responseBase.Message = "Cliente Inválido";
                        responseBase.Success = false;

                        return responseBase;
                    }

                    _clientRepository.Insert(newClient);

                }               
            }
            catch (Exception)
            {

                responseBase.Message = "Não foi possível adicionar o cliente";
            }

            return responseBase;
        }
    }
}
