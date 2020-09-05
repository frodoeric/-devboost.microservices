using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace devboost.Domain.Model
{
    public class PagamentoCartao : Pagamento
    {
        public PagamentoCartao(string bandeira, string numero, DateTime vencimento, int codigoSeguranca, decimal valor, StatusCartao status)
        {
            Id = Guid.NewGuid();
            Bandeira = bandeira;
            Numero = numero;
            Vencimento = vencimento;
            CodigoSeguranca = codigoSeguranca;
            Valor = valor;
            Status = status;
        }

        public Guid Id { get; set; }
        public string Bandeira { get; set; }
        public string Numero { get; set; }
        public DateTime Vencimento { get; set; }
        public int CodigoSeguranca { get; set; }
        public StatusCartao Status { get; set; }

        [NotMapped]
        public string DescricaoStatus
        {
            get
            {
                switch (Status)
                {
                    case StatusCartao.aguardandoAprovacao:
                        return "Aguardando Aprovação";
                    case StatusCartao.aprovado:
                        return "Aprovado";
                    case StatusCartao.recusado:
                        return "Recusado";
                    default:
                        return string.Empty;
                }
            }
        }

        public List<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }

    public enum StatusCartao
    {
        aguardandoAprovacao = 1,
        aprovado = 2,
        recusado = 3
    }
}
