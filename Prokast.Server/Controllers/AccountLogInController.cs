//using AutoMapper;
using Prokast.Server.Entities;
using Prokast.Server.Models;
using Prokast.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Prokast.Server.Models.ResponseModels;
using static System.Runtime.InteropServices.JavaScript.JSType;
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

        #region LogIn
        [HttpPost]
        [ProducesResponseType(typeof(LogInLoginResponse),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public ActionResult<Response> Log_In([FromBody] LoginRequest loginRequest) 
        {
            try 
            { 
                var response = _LogInService.Log_In(loginRequest);
                if (response is ErrorResponse) return BadRequest(response);
                return Ok(response);
            }catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region GetAll
        [HttpGet]
        [ProducesResponseType(typeof(LogInGetResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public ActionResult<Response> GetAll([FromQuery] int clientID) 
        {
            try
            {
                var logins = _LogInService.GetLogIns(clientID);
                if (logins is ErrorResponse) return BadRequest(logins);
                return Ok(logins);
            }
            catch (Exception ex) 
            {
                return NotFound(ex.Message);
            }   
        }
        #endregion

        [HttpPost("create")]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public ActionResult<Response> CreateAccount([FromBody] AccountCreateDto accountCreate,[FromQuery] int clientID)
        {
            try
            {
                var result = _LogInService.CreateAccount(accountCreate, clientID);
                if (result is ErrorResponse) return BadRequest(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(AccountEditResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public ActionResult<Response> EditAccount([FromBody] AccountEditDto accountEdit, [FromQuery] int clientID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Błędne dane");
            }
            try
            {
                var result = _LogInService.EditAccount(accountEdit, clientID);
                if (result is ErrorResponse) return BadRequest(result);

                if (result == null) return NotFound(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
