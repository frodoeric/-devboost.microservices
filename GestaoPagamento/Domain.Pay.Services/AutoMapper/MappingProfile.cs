using AutoMapper;
using Domain.Pay.Entities;
using Domain.Pay.Services.Commands.Payments;
using Domain.Pay.Services.Dtos.Payments;

namespace Domain.Pay.Services.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Command
            CreateMap<CriarPaymentCommand, Payment>()
                .ConstructUsing(c => Payment.Criar(c.PayId, c.CreatedAt, c.Name, c.Bandeira, c.NumeroCartao, c.Vencimento, c.CodigoSeguranca, c.Valor, c.Status));

            CreateMap<Payment, PaymentDto>();
            CreateMap<PaymentDto, Payment>();
        }
    }
}
