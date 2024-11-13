using Microsoft.AspNetCore.Mvc;
using Prokast.Server.Entities;
using Prokast.Server.Models;

namespace Prokast.Server.Services
{
    public interface IParamsService
    {
        Response CreateCustomParam([FromBody] CustomParamsDto customParamsDto, int clientID);
    }
}
