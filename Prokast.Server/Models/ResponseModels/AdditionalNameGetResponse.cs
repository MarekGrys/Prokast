using Prokast.Server.Entities;

namespace Prokast.Server.Models.ResponseModels
{
    public class AdditionalNameGetResponse : Response
    {
        public List<AdditionalName> Model { get; set; }
    }
}
