using Microsoft.AspNetCore.Mvc;
using Prokast.Server.Entities;
using Prokast.Server.Models;

namespace Prokast.Server.Services.Interfaces
{
    public interface IPhotoService
    {
        Response GetAllPhotos(int clientID);
        Response GetPhotosByID(int clientID, int ID);
        Response EditPhotos(int clientID, int ID, PhotoEdit data);
        Response DeletePhotos(int clientID, int ID);
    }
}
