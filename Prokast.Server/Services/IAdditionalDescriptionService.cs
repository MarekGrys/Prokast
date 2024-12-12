using Microsoft.AspNetCore.Mvc;
using Prokast.Server.Models;

namespace Prokast.Server.Services
{
    public interface IAdditionalDescriptionService
    {
        Response CreateAdditionalDescription([FromBody] AdditionalDescriptionCreateDto description, int clientID);
        Response GetAllDescriptions(int clientID);
        Response GetDescriptionsByID(int ID, int clientID);
        Response GetDescriptionsByNames(string Title, int clientID);
        Response GetDescriptionByRegion(int Region, int clientID);
    }
}
