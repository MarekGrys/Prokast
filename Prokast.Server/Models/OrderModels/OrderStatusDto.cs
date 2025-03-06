using Prokast.Server.Enums;
using System.Text.Json.Serialization;

namespace Prokast.Server.Models.OrderModels
{
    public class OrderStatusDto
    {
        //[JsonConverter(typeof(JsonStringEnumConverter))]
        public OrderStatus OrderStatus { get; set; }
    }
}
