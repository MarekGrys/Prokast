


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.AspNetCore.Mvc;

using Prokast.Server.Models;
using Prokast.Server.Services;
namespace RRegistration.Controllers
{
    [Route("api/client")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        [HttpPost]
        public ActionResult<Clients> RegisterClient([FromBody] Registration registration)
        {
            try 
            {
                _clientService.RegisterClient(registration);
                return Created();
            } catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}