using Microsoft.AspNetCore.Mvc;
using Prokast.Server.Entities;
using Prokast.Server.Models;
using Prokast.Server.Models.ResponseModels;
using Prokast.Server.Services;

namespace Prokast.Server.Controllers
{
    [Route("api/products")]
    public class ProductController: ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        #region Create
        [HttpPost]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public ActionResult<Response> CreateProduct([FromBody] ProductCreateDto productCreateDto, [FromQuery] int clientID)
        {
            try
            {
                var result = _productService.CreateProduct(productCreateDto, clientID);
                if (result is ErrorResponse) return BadRequest(result);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        [HttpPost("Get")]
        [ProducesResponseType(typeof(ProductsGetResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public ActionResult<Response> GetProducts([FromBody] ProductGetFilter filter, int clientID)
        {
            try
            {
                var result = _productService.GetProducts(filter, clientID);
                if (result is ErrorResponse) return BadRequest(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
