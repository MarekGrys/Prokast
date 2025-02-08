using Microsoft.AspNetCore.Mvc;
using Prokast.Server.Models.ResponseModels;
using Prokast.Server.Models;
using Prokast.Server.Services;
using Prokast.Server.Services.Interfaces;


namespace Prokast.Server.Controllers
{
    [Route("api/storedproducts")]
    public class StoredProductController: ControllerBase
    {
        private readonly IStoredProductService _storedProductService;

        public StoredProductController(IStoredProductService storedProductService)
        {
            _storedProductService = storedProductService;
        }

        #region Create
        [HttpPost]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public ActionResult<Response> CreateWarehouse([FromBody] StoredProductCreateMultipleDto storedProducts, [FromQuery] int warehouseID, [FromQuery] int clientID)
        {
            try
            {
                var result = _storedProductService.CreateStoredProduct(storedProducts, warehouseID, clientID);
                if (result is ErrorResponse) return BadRequest(result);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Get
        [HttpGet]
        [ProducesResponseType(typeof(StoredProductGetResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public ActionResult<Response> GetAllStoredProducts([FromQuery] int clientID,[FromQuery] int warehouseID)
        {
            try
            {
                var result = _storedProductService.GetAllStoredProducts(clientID, warehouseID);
                if (result is ErrorResponse) return BadRequest(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{ID}")]
        [ProducesResponseType(typeof(StoredProductGetResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public ActionResult<Response> GetStoredProductByID([FromQuery] int clientID,[FromRoute] int ID)
        {
            try
            {
                var result = _storedProductService.GetStoredProductByID(clientID, ID);
                if (result is ErrorResponse) return BadRequest(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("below")]
        [ProducesResponseType(typeof(StoredProductGetResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public ActionResult<Response> GetStoredProductsBelowMinimum([FromQuery] int clientID,[FromQuery] int warehouseID)
        {
            try
            {
                var result = _storedProductService.GetStoredProductsBelowMinimum(clientID, warehouseID);
                if (result is ErrorResponse) return BadRequest(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Delete
        [HttpDelete("{ID}")]
        [ProducesResponseType(typeof(DeleteResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public ActionResult<Response> DeleteWarehouse([FromQuery] int clientID, [FromRoute] int ID)
        {

            try
            {
                var result = _storedProductService.DeleteStoredProduct(clientID, ID);
                if (result is ErrorResponse) return BadRequest(result);

                if (result == null) return NotFound(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
