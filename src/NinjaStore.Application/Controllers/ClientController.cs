using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NinjaStore.Domain.DTO;
using NinjaStore.Domain.Interfaces.Services;
using NinjaStore.Domain.Resources;
using System;
using System.Net;
using System.Threading.Tasks;

namespace NinjaStore.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Post")]
        public ActionResult AddClient([FromBody] CreateClient model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                ResponseBase result = _clientService.CreateClient(model);
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

    }
}
