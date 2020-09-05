using System;

namespace Domain.Pay.Services.Commands.Payments
{
    public class CriarPaymentCommand
    {
        public DateTime CreatedAt { get; }

        public string Name { get; private set; }

        public string Bandeira { get; }

        public string NumeroCartao { get; }

        public DateTime Vencimento { get; }

        public int CodigoSeguranca { get; }

        public double Valor { get; }

        public string Status { get; }

        public CriarPaymentCommand(DateTime createdAt, string name, string bandeira)
        {

        }
    }
}
