using Microsoft.AspNetCore.Mvc;
using Prokast.Server.Models;

namespace Prokast.Server.Services
{
    public interface IAdditionalDescriptionService
    {
        Task<Response> CreateAdditionalDescription([FromBody] AdditionalDescriptionCreateDto description, int clientID);
        Task<Response> GetAllDescriptions(int clientID);
        Task<Response> GetDescriptionsByID(int ID, int clientID);
        Task<Response> GetDescriptionsByNames(string Title, int clientID);
        Task<Response> GetDescriptionByRegion(int Region, int clientID);
        Task<Response> EditAdditionalDescription(int clientID, int ID, AdditionalDescriptionCreateDto data);
        Task<Response> DeleteAdditionalDescription(int clientID, int ID);
    }
}
