using Prokast.Server.Models;

namespace Prokast.Server.Models.ResponseModels
{
    public class AccountCreateResponse: Response
    {
        public AccountCreateDto Model { get; set; }
    }
}
