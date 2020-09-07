using Integration.Pay.Dto;
using Integration.Pay.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Integration.Pay.Service
{
    public class WebHook : IWebHook
    {
        readonly string _webHookUrl;
        readonly string _webHookMethod;

        public WebHook(IConfiguration configuration)
        {
            _webHookUrl = configuration["WebHook:url"];
            _webHookMethod = configuration["WebHook:method"];
        }

        public async Task<PostMethodResultDto> CallPostMethod(WebHookMethodRequestDto webHookMethodRequestDto)
        {
            var jsonContent = new StringContent(JsonConvert.SerializeObject(webHookMethodRequestDto), Encoding.UTF8, "application/json");
            var postRequest = new PostMethodRequestDto(
                url: _webHookUrl,
                method: _webHookMethod,
                bodyRequest: jsonContent
            );
            var result = HttpPostService.HttpPost(postRequest);
            var msgResult = (result.StatusCode == HttpStatusCode.OK)
                ? "Método executado com sucesso"
                : "Falha na execução do método";
            return await Task.FromResult(new PostMethodResultDto
            { 
                StatusCode = result.StatusCode,
                ContentResult = msgResult
            });
        }
    }
}
