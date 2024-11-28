using Prokast.Server.Entities;

namespace Prokast.Server.Models.ResponseModels
{
    public class PricesGetResponse: Response
    {
        public List<Prices> Model { get; set; }
    }
}
