using Flunt.Notifications;
using Flunt.Validations;
using Newtonsoft.Json;
using System;

namespace Domain.Pay.Services.Commands.Payments
{
    public class CriarPaymentCommand : Notifiable
    {
        public Guid PayId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string Bandeira { get; set; }
        public string NumeroCartao { get; set; }
        public DateTime Vencimento { get; set; }
        public int CodigoSeguranca { get; set; }
        public double Valor { get; set; }
        public int Status { get; set; }

        [JsonConstructor]
        public CriarPaymentCommand(Guid payId, DateTime createdAt, string name, string bandeira, string numeroCartao, DateTime vencimento, int codigoSeguranca, double valor, int status)
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

        public CriarPaymentCommand() { }

        public void Validar()
        {
            AddNotifications(new Contract().Requires().IsGreaterThan(Valor, 0, nameof(Valor), "Valor deve ser maior que zero"));
            AddNotifications(new Contract().Requires().IsGreaterThan(CodigoSeguranca, 0, nameof(CodigoSeguranca), "CodigoSegurança deve ser maior que zero"));
            AddNotifications(new Contract().Requires().HasMaxLen(NumeroCartao, 16, nameof(NumeroCartao), "NumeroCartao deve ter no máximo 16 dígitos"));
            AddNotifications(new Contract().Requires().HasMinLen(NumeroCartao, 16, nameof(NumeroCartao), "NumeroCartao deve ter no mínimo 16 dígitos"));
            AddNotifications(new Contract().Requires().HasMaxLen(Bandeira, 30, nameof(Bandeira), "Bandeira pode ter no máximo 30 dígitos"));
            AddNotifications(new Contract().Requires().HasMinLen(Bandeira, 3, nameof(Bandeira), "Bandeira não pode ter menos 3 dígitos"));
            AddNotifications(new Contract().Requires().IsGreaterThan(Status, 0, nameof(Status), "Status deve ser maior que zero"));
        }
    }
}
