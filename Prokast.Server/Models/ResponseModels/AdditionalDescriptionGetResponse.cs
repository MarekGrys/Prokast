using Prokast.Server.Entities;

namespace Prokast.Server.Models.ResponseModels
{
    public class AdditionalDescriptionGetResponse: Response
    {
        public List<AdditionalDescription> Model { get; set; }
    }
}
