using System;

namespace devboost.Domain.Commands.Request
{
    public class RealizarPedidoRequest
    {
        public int Peso { get; set; }
        public string Bandeira { get; set; }
        public string Numero { get; set; }
        public DateTime Vencimento { get; set; }
        public int CodigoSeguranca { get; set; }
        public decimal Valor { get; set; }
    }
}
