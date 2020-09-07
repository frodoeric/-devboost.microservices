using System;
using System.Text.Json.Serialization;

namespace Integration.Pay.Dto
{
    public class WebHookMethodRequestDto
    {
        [JsonPropertyName("payId")]
        public Guid PayId { get; set; }
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("bandeira")]
        public string Bandeira { get; set; }
        [JsonPropertyName("numeroCartao")]
        public string NumeroCartao { get; set; }
        [JsonPropertyName("vencimento")]
        public DateTime Vencimento { get; set; }
        [JsonPropertyName("codigoSeguranca")]
        public int CodigoSeguranca { get; set; }
        [JsonPropertyName("valor")]
        public decimal Valor { get; set; }
        [JsonPropertyName("status")]
        public int Status { get; set; }
    }
}
