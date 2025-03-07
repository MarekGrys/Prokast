using System.Text.Json.Serialization;

namespace Prokast.Server.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PaymentStatus
    {
        pending,
        paid,
        failed,
        returned
    }
}
