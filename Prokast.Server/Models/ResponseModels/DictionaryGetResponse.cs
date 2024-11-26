using Prokast.Server.Entities;

namespace Prokast.Server.Models.ResponseModels
{
    public class DictionaryGetResponse: Response
    {
        public List<DictionaryParams> Model { get; set; }
    }
}
