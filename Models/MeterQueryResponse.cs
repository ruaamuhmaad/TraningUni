using System.Text.Json.Serialization;

namespace BlazorAssiment.Models
{
    public class MeterQueryResponse
    {
        [JsonPropertyName("account_number")]
        public string AccountNumber { get; set; } = string.Empty;

        [JsonPropertyName("account_used")]
        public string AccountUsed { get; set; } = string.Empty;

        [JsonPropertyName("customer_name")]
        public string CustomerName { get; set; } = string.Empty;

        [JsonPropertyName("meter_number")]
        public string MeterNumber { get; set; } = string.Empty;

        [JsonPropertyName("query_ref")]
        public string QueryRef { get; set; } = string.Empty;

        [JsonPropertyName("adjustments")]
        public decimal Adjustments { get; set; }

        [JsonPropertyName("recharge_amount")]
        public decimal RechargeAmount { get; set; }

        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonPropertyName("adjustments_details")]
        public List<AdjustmentDetail> AdjustmentsDetails { get; set; } = new();
    }

    public class AdjustmentDetail
    {
        [JsonPropertyName("adjustmentName")]
        public string AdjustmentName { get; set; } = string.Empty;

        [JsonPropertyName("adjustmentRemains")]
        public string AdjustmentRemains { get; set; } = string.Empty;

        [JsonPropertyName("adjustmentValue")]
        public string AdjustmentValue { get; set; } = string.Empty;
    }
}

