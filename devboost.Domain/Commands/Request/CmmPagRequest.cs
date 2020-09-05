using devboost.Domain.Model;
using System;

namespace devboost.Domain
{
    public class CmmPagRequest
    {
        public Guid PayId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string Bandeira { get; set; }
        public string NumeroCartao { get; set; }
        public DateTime Vencimento { get; set; }
        public int CodigoSeguranca { get; set; }
        public decimal Valor { get; set; }
        public StatusCartao Status { get; set; }
    }
}
