using System.Text.Json.Serialization;

namespace Prokast.Server.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OrderStatus
    {
        pending,
        processing,
        shipped,
        delivered,
        cancelled,
        refunded
    }
}
