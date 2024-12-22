using Microsoft.AspNetCore.Mvc;
using Prokast.Server.Entities;
using Prokast.Server.Models;

namespace Prokast.Server.Services
{
    public interface IDictionaryService
    {
        
        Task<Response> GetAllParams();
        Task<Response> GetParamsByID( int ID);
        Task<Response> GetParamsByName( string name);
        Task<Response> GetParamsByRegion(int region);
        Task<Response> GetValuesByName(string name);
    }
}
