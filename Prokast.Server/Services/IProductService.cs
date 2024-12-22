using Microsoft.AspNetCore.Mvc;
using Prokast.Server.Models;
using Prokast.Server.Models.ResponseModels;

namespace Prokast.Server.Services
{
    public interface IProductService
    {
        Task<Response> CreateProduct([FromBody] ProductCreateDto productCreateDto, int clientID);
        Task<Response> GetProducts([FromBody] ProductGetFilter productGetFilter, int clientID);
        Task<DeleteResponse> DeleteProduct(int clientID, int productID);
        Task<Response> EditProduct(ProductEdit productEdit, int clientID, int productID);
        
        }
}
