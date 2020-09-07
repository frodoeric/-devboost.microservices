using System;
using System.Text.Json.Serialization;

namespace Integration.Pay.Dto
{
    public class PayOperatorFilterDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("Bandeira")]
        public string Bandeira { get; set; }
        [JsonPropertyName("NumeroCartao")]
        public string NumeroCartao { get; set; }
        [JsonPropertyName("Vencimento")]
        public DateTime Vencimento { get; set; }
        [JsonPropertyName("CodigoSeguranca")]
        public int CodigoSeguranca { get; set; }
        [JsonPropertyName("Valor")]
        public decimal Valor { get; set; }
        [JsonPropertyName("Status")]
        public string Status { get; set; }
    }
}
