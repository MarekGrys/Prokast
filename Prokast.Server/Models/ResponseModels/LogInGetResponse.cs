using Prokast.Server.Entities;

namespace Prokast.Server.Models.ResponseModels
{
    public class LogInGetResponse: Response
    {
        public List<AccountLogIn> Model { get; set; }
    }
}
