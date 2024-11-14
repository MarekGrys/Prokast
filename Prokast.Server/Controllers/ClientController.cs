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
                return response;
            } catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}