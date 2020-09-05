using System;

namespace Domain.Pay.Services.Commands.Payments
{
    public class CriarPaymentCommand
    {
        public Guid PayId { get; }

        public DateTime CreatedAt { get; }

        public string Name { get; private set; }

        public string Bandeira { get; }

        public string NumeroCartao { get; }

        public DateTime Vencimento { get; }

        public int CodigoSeguranca { get; }

        public double Valor { get; }

        public int Status { get; }

        
        public CriarPaymentCommand(DateTime createdAt, string name, string bandeira, string numeroCartao, DateTime vencimento, int codigoSeguranca, double valor, int status)
        {
            CreatedAt = createdAt;
            Name = name;
            Bandeira = bandeira;
            NumeroCartao = numeroCartao;
            Vencimento = vencimento;
            CodigoSeguranca = codigoSeguranca;
            Valor = valor;
            Status = status;
        }
    }
}
