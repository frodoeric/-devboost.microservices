using Integration.Pay.Dto;
using Integration.Pay.Interfaces;
using System;
using System.Threading.Tasks;

namespace Integration.Pay.Service
{
    public class WebHook : IWebHook
    {
        public async Task<string> CallPostMethod(PostMethodRequestDto postMethodDto)
        {
            //var result = HttpPostService.HttpPost(postRequest);
            //if (result.StatusCode == HttpStatusCode.OK)
            //{

            //}
            throw new NotImplementedException();
        }
    }
}
