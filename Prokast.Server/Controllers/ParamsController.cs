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

        #region CreateCustomParam
        [HttpPost]
        public ActionResult<Response> CreateCustonParam([FromBody] CustomParamsDto customParamsDto, [FromQuery] int clientID)
        {
            try 
            {
                var response = _paramsService.CreateCustomParam(customParamsDto, clientID);
                return response;
            } catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region GetAllParams
        [HttpGet]
        public ActionResult<Response> GetAllParams([FromQuery] int clientID) 
        {
            try
            {
                var lista = _paramsService.GetAllParams(clientID);
                if (lista.Model is string) return NotFound(lista);
                return lista;
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region GetParamsByID
        [HttpGet("{ID}")]
        public ActionResult<Response> GetParamsByID([FromQuery] int clientID, [FromRoute] int ID)
        {
            try
            {
                var param = _paramsService.GetParamsByID(clientID, ID);
                if (param.Model is string) return NotFound(param);
                return param;
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region getParamsByName
        [HttpGet("/name/{name}")]
        public ActionResult<Response> GetParamsByName([FromQuery] int clientID, [FromRoute] string name)
        {
            try
            {
                var param = _paramsService.GetParamsByName(clientID, name);
                if (param.Model is string) return NotFound(param);
                return param;
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            
        }
        #endregion

    }
}
