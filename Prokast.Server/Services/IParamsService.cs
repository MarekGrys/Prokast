using Microsoft.AspNetCore.Mvc;
using Prokast.Server.Entities;
using Prokast.Server.Models;

namespace Prokast.Server.Services
{
    public interface IParamsService
    {
        Response CreateCustomParam([FromBody] CustomParamsDto customParamsDto, int clientID);
        Response GetAllParams(int clientID);
        Response GetParamsByID(int clientID, int ID);
        Response GetParamsByName(int clientID, string name);
        Response EditParams(int clientID, int ID, CustomParamsDto data);
        Response DeleteParams(int clientID, int ID);
    }
}
