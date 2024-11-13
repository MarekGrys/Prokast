using Microsoft.AspNetCore.Mvc;
using Prokast.Server.Entities;
using Prokast.Server.Services;
using Prokast.Server.Models;

namespace Prokast.Server.Controllers
{
    [Route("api/params")]
    public class ParamsController: ControllerBase
    {
        private readonly IParamsService _paramsService;

        public ParamsController(IParamsService paramsService)
        {
            _paramsService = paramsService;
        }

        [HttpPost]
        public ActionResult<CustomParams> CreateCustonParam([FromBody] CustomParamsDto customParamsDto, [FromQuery] int clientID)
        {
            try 
            {
                _paramsService.CreateCustomParam(customParamsDto, clientID);
                return Created();
            } catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
