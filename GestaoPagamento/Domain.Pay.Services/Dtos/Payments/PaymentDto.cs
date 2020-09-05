using System;

namespace Domain.Pay.Services.Dtos.Payments
{
    public class PaymentDto
    {
        public Guid PayId { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public string Name { get; private set; }

        public string Bandeira { get; private set; }

        public string NumeroCartao { get; private set; }

        public DateTime Vencimento { get; private set; }

        public int CodigoSeguranca { get; private set; }

        public double Valor { get; private set; }

        public string Status { get; private set; }
    }
}
