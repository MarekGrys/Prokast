using Microsoft.AspNetCore.Mvc;
using Prokast.Server.Entities;
using Prokast.Server.Models;

namespace Prokast.Server.Services
{
    public interface IParamsService
    {
        Task<Response> CreateCustomParam([FromBody] CustomParamsDto customParamsDto, int clientID);
        Task<Response> GetAllParams(int clientID);
        Task<Response> GetParamsByID(int clientID, int ID);
        Task<Response> GetParamsByName(int clientID, string name);
        Task<Response> EditParams(int clientID, int ID, CustomParamsDto data);
        Task<Response> DeleteParams(int clientID, int ID);
    }
}
