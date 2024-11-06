using Microsoft.AspNetCore.Mvc;
using Prokast.Server.Entities;
using Prokast.Server.Models;

namespace Prokast.Server.Services
{
    public interface ILogInService
    {
        List<AccountLogIn> GetLogIns();
        void Log_In([FromBody] LoginRequest loginRequest);
    }
}