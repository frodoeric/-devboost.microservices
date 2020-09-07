using AutoMapper;
using Domain.Pay.Core;
using Domain.Pay.Core.Validador;
using Domain.Pay.Entities;
using Domain.Pay.Services.CommandHandlers.Interfaces;
using Domain.Pay.Services.Commands.Payments;
using Integration.Pay.Dto;
using Integration.Pay.Interfaces;
using Newtonsoft.Json;
using Repository.Pay.UnitOfWork;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Pay.Services.CommandHandlers
{
    public class CriarPaymentHandler : ValidadorResponse, ICriarPaymentHandler
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IMapper _mapper;
        readonly IPayAtOperatorService _payAtOperatorService;
        readonly IWebHook _webHook;

        public CriarPaymentHandler(IUnitOfWork unitOfWork, IMapper mapper, IWebHook webHook, IPayAtOperatorService payAtOperatorService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _payAtOperatorService = payAtOperatorService;
            _webHook = webHook;
        }

        public async Task<ResponseResult> Handle(CriarPaymentCommand request)
        {
            request.Validar();

            if (request.Notifications.Any())
            {
                _response.AddNotifications(request.Notifications);
                return _response;
            }

            // Armazena informação da transação de pagamento
            var payment = _mapper.Map<Payment>(request);
            await _unitOfWork.PaymentRepository.InsertAsync(payment);
            await _unitOfWork.CommitAsync();

            // Chama MockAPI para tratar pagamento
            await _payAtOperatorService.ValidadePayAtOperator(new PayOperatorFilterDto());

            // Retorna para API cadastrada como WebHook
            var jsonContent = new StringContent(JsonConvert.SerializeObject(payment), Encoding.UTF8, "application/json");
            await _webHook.CallPostMethod(new PostMethodRequestDto("url", "method", jsonContent));

            return _response;
        }
    }
}
