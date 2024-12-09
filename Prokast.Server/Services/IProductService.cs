using Microsoft.AspNetCore.Mvc;
using Prokast.Server.Models;
using Prokast.Server.Models.ResponseModels;

namespace Prokast.Server.Services
{
    public interface IProductService
    {
        Response CreateProduct([FromBody] ProductCreateDto productCreateDto, int clientID);
        Response GetProducts([FromBody] ProductGetFilter productGetFilter, int clientID);
        DeleteResponse DeleteProduct(int clientID, int productID);
        Response EditProduct(ProductEdit productEdit, int clientID, int productID);
        
        }
}
