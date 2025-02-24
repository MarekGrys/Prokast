using Prokast.Server.Entities;

namespace Prokast.Server.Models.ResponseModels
{
    public class StoredProductEditMulipleResponse: Response
    {
        public List<StoredProduct> Model { get; set; }
    }
}
