using Microsoft.AspNetCore.Mvc;
using Prokast.Server.Models;

namespace Prokast.Server.Services
{
    public interface IClientService
    {
        Task<Response> RegisterClient([FromBody] Registration registration);
    }
}
