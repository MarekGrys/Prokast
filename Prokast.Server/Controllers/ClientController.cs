using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Prokast.Server.Models;
using Prokast.Server.Services;
namespace Prokast.Server.Controllers
{
    [Route("api/client")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        #region RegisterClient
        [HttpPost]
        public ActionResult<Response> RegisterClient([FromBody] Registration registration)
        {
            try 
            {
                var response = _clientService.RegisterClient(registration);
                if (response.Model is string) return BadRequest(response);
                return Created();
            } catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}