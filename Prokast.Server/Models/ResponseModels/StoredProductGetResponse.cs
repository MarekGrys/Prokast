using Prokast.Server.Entities;

namespace Prokast.Server.Models.ResponseModels
{
    public class StoredProductGetResponse: Response
    {
        public List<StoredProduct> Model { get; set; }
    }
}
