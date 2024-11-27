using Prokast.Server.Entities;

namespace Prokast.Server.Models.ResponseModels
{
    public class ClientRegisterResponse: Response
    {
        public Registration Registration { get; set; }
    }
}
