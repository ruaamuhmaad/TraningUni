using System.Text.Json.Serialization;

namespace BlazorAssiment.Models
{
    public class PaymentResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("meter_number")]
        public string MeterNumber { get; set; } = string.Empty;

        [JsonPropertyName("customer_name")]
        public string CustomerName { get; set; } = string.Empty;

        [JsonPropertyName("account_number")]
        public string AccountNumber { get; set; } = string.Empty;

        [JsonPropertyName("token")]
        public string Token { get; set; } = string.Empty;

        [JsonPropertyName("reference_number")]
        public string ReferenceNumber { get; set; } = string.Empty;

        [JsonPropertyName("account_used")]
        public string AccountUsed { get; set; } = string.Empty;

        [JsonPropertyName("amount_paid")]
        public decimal AmountPaid { get; set; }

        [JsonPropertyName("units_added")]
        public decimal UnitsAdded { get; set; }

        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }
    }
}
