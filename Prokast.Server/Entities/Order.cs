using Prokast.Server.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Prokast.Server.Entities
{
    public class Order
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string OrderID { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OrderStatus OrderStatus { get; set; } = OrderStatus.pending;
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public decimal TotalWeightKg { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
        [Required]
        [RegularExpression("^(pending|paid|failed|refunded)$", ErrorMessage = "PaymentStatus musi mieć jedną z dozwolonych wartości.")]
        public string PaymentStatus { get; set; } = "pending";
        [Required]
        public DateTime UpdateDate { get; set; }
        public string? TrackingID { get; set; }
        [Required]
        public int ClientID { get; set; }
        [Required]
        public int CustomerID { get; set; }
        public int? BusinessID { get; set; }
        [Required]
        public bool IsBusiness { get; set; }
    }
}
