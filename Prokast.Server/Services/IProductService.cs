using Microsoft.AspNetCore.Mvc;
using Prokast.Server.Models;

namespace Prokast.Server.Services
{
    public interface IProductService
    {
        Response CreateProduct([FromBody] ProductCreateDto productCreateDto, int clientID);
    }
}
