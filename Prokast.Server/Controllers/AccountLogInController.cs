//using AutoMapper;
using Prokast.Server.Entities;
using Prokast.Server.Models;
using Prokast.Server.Services;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;


namespace Prokast.Server.Controllers
{
    [Route("api/login")]
    public class AccountLogInController : ControllerBase
    {
        private readonly ILogInService _LogInService;



        public AccountLogInController(ILogInService logInService)
        {
            _LogInService = logInService;
        }
        [HttpPost]
        public ActionResult<AccountLogIn> Log_In([FromBody] LoginRequest loginRequest) 
        {
            try 
            { 
                _LogInService.Log_In(loginRequest);
                return Ok();
            }catch (Exception ex) { 
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<AccountLogIn>> GetAll() 
        {
            try
            {
                var logins = _LogInService.GetLogIns();
                return logins;
            }
            catch (Exception ex) 
            {
                return NotFound(ex.Message);
            }   
        }
    }
}
