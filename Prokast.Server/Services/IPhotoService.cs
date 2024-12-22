using Microsoft.AspNetCore.Mvc;
using Prokast.Server.Entities;
using Prokast.Server.Models;

namespace Prokast.Server.Services
{
    public interface IPhotoService 
    {
        Task<Response> GetAllPhotos(int clientID);
        Task<Response> GetPhotosByID(int clientID, int ID);
        Task<Response> EditPhotos(int clientID, int ID, PhotoEdit data);
        Task<Response> DeletePhotos(int clientID, int ID);
    }
}
