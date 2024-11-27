using Microsoft.AspNetCore.Mvc;
using Prokast.Server.Entities;
using Prokast.Server.Services;
using Prokast.Server.Models;
using Prokast.Server.Models.ResponseModels;




namespace Prokast.Server.Controllers
{
    [Route("api/prices")]
    public class PricesController : ControllerBase
    {
        private readonly IPricesService _priceService;
        public PricesController(IPricesService pricesService)
        {
            _priceService = pricesService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public ActionResult<Response> CreatePriceList([FromBody] PriceListsDto priceLists, [FromQuery] int clientID)
        {
            try
            {
                var result = _priceService.CreatePriceList(priceLists, clientID);
                if (result is ErrorResponse) return BadRequest(result);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("{priceListID}")]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public ActionResult<Response> CreatePrice([FromBody] PricesDto prices, [FromRoute] int priceListID, [FromQuery] int clientID)
        {
            try
            {
                var result = _priceService.CreatePrice(prices, priceListID, clientID);
                if (result is ErrorResponse) return BadRequest(result);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
