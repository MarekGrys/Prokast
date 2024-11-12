using Microsoft.AspNetCore.Mvc;
using Prokast.Server.Models;

namespace Prokast.Server.Services
{
    public interface IClientService
    {
        Response RegisterClient([FromBody] Registration registration);
    }
}
