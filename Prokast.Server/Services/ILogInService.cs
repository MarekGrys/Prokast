using Microsoft.AspNetCore.Mvc;
using Prokast.Server.Entities;
using Prokast.Server.Models;

namespace Prokast.Server.Services
{
    public interface ILogInService
    {
        Task<Response> GetLogIns(int clientID);
        Task<Response> Log_In([FromBody] LoginRequest loginRequest);
    }
}