//using AutoMapper;
using Prokast.Server.Entities;
using Prokast.Server.Models;
using Prokast.Server.Services;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;


namespace Prokast.Server.Controllers
{
    [Route("api/login")]
    public class AccountController : ControllerBase
    {
        private readonly ILogInService _LogInService;



        public AccountController(ILogInService logInService)
        {
            _LogInService = logInService;
        }
        [HttpPost]
        public ActionResult<Account> Log_In([FromBody] LoginRequest loginRequest) 
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
        public ActionResult<IEnumerable<Account>> GetAll() 
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
