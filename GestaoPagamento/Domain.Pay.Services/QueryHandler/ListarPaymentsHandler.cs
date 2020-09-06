using AutoMapper;
using Domain.Pay.Core;
using Domain.Pay.Core.Validador;
using Domain.Pay.Entities;
using Domain.Pay.Services.Dtos.Payments;
using Domain.Pay.Services.Queries.Payments;
using Domain.Pay.Services.QueryHandler.Interfaces;
using Microsoft.EntityFrameworkCore;
using Repository.Pay.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Pay.Services.QueryHandler
{
    public class ListarPaymentsHandler : ValidadorResponse, IListarPaymentsHandler
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ListarPaymentsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseResult> Handle(PaymentsQuery paymentsQuery)
        {
            var paymemts = await _unitOfWork.PaymentRepository.Table.ToListAsync();

            _response.AddValue(new
            {
                payment = _mapper.Map<IEnumerable<Payment>, IEnumerable<PaymentDto>>(paymemts)
            });

            return _response;
        }
    }
}
