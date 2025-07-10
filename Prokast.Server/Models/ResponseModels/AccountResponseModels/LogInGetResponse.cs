using Prokast.Server.Entities;

namespace Prokast.Server.Models.ResponseModels.AccountResponseModels
{
    public class LogInGetResponse : Response
    {
        public List<Account> Model { get; set; }
    }
}
