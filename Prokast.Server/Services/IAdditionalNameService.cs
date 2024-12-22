using Microsoft.AspNetCore.Mvc;
using Prokast.Server.Entities;
using Prokast.Server.Models;

namespace Prokast.Server.Services
{
    public interface IAdditionalNameService
    {
        Task<Response> CreateAdditionalName([FromBody] AdditionalNameDto additionalNameDto, int clientID);
        Task<Response> GetAllNames(int clientID);
        Task<Response> GetNamesByID(int ID, int clientID);
        Task<Response> GetNamesByIDNames(int ID, string Title, int clientID);
        Task<Response> GetNamesByIDRegion(int ID, int Region, int clientID);
        Task<Response> EditAdditionalName(int clientID, int ID, AdditionalNameDto data);
        Task<Response> DeleteAdditionalName(int clientID, int ID);
    }
}