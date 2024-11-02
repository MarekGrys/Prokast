using AutoMapper;
using Prokast.Server.Entities;
//using Prokast.Server.Models;
using Prokast.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Prokast.Server.Controllers
{
    [Route("api/login")]
    public class Account_Log_InController: ControllerBase
    {
        private readonly ILogInService _Log_InService;

        public Account_Log_InController(ILogInService logInService)
        {
            _Log_InService = logInService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Account_Log_In2>> GetAll() 
        {
            try
            {
                var logins = _Log_InService.GetLogIns();
                return logins;
            }
            catch (Exception ex) 
            {
                return NotFound(ex.Message);
            }
            
        }
    }
}
