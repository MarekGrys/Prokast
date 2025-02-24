using Prokast.Server.Entities;

namespace Prokast.Server.Models.ResponseModels
{
    public class WarehouseGetResponse: Response
    {
        public List<Warehouse> Model { get; set; }
    }
}
