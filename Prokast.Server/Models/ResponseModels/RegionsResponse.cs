using Prokast.Server.Entities;

namespace Prokast.Server.Models.ResponseModels
{
    public class RegionsResponse: Response
    {
        public List<Regions> Model { get; set; }
    }
}
