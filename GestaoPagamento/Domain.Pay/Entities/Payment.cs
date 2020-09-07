using Domain.Pay.Core;
using System;

namespace Domain.Pay.Entities
{
    public class Payment : Entity
    {
        public Guid PayId { get; }

        public DateTime CreatedAt { get; }

        public string Name { get; }

        public string Bandeira { get; }

        public string NumeroCartao { get; }

        public DateTime Vencimento { get; }

        public int CodigoSeguranca { get; }

        public double Valor { get; }

        public int Status { get; }

        public Payment() { }

        public Payment(Guid payId, DateTime createdAt, string name, string bandeira, string numeroCartao, DateTime vencimento, int codigoSeguranca, double valor, int status)
        {
            PayId = payId;
            CreatedAt = createdAt;
            Name = name;
            Bandeira = bandeira;
            NumeroCartao = numeroCartao;
            Vencimento = vencimento;
            CodigoSeguranca = codigoSeguranca;
            Valor = valor;
            Status = status;
        }

        public static Payment Criar(Guid payId, DateTime createdAt, string name, string bandeira, string numeroCartao, DateTime vencimento, int codigoSeguranca, double valor, int status)
        {
            return new Payment(payId, createdAt, name, bandeira, numeroCartao, vencimento, codigoSeguranca, valor, status);
        }
    }
}
