using Prokast.Server.Models;

namespace Prokast.Server.Services
{
    public interface IOthersService
    {
        Task<Response> GetRegions();
    }
}
