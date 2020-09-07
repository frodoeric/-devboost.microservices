using System;
using System.Text.Json.Serialization;

namespace Integration.Pay.Dto
{
    public class PayOperatorResultDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("CreditCardPaymentId")]
        public int CreditCardPaymentId { get; set; }
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }
        [JsonPropertyName("Status")]
        public bool Status { get; set; }
    }
}
