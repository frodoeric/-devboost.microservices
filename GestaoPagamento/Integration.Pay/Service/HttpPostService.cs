using Integration.Pay.Dto;
using System;
using System.Net;
using System.Net.Http;

namespace Integration.Pay.Service
{
    public static class HttpPostService
    {
        public static PostMethodResultDto HttpPost(PostMethodRequestDto postMethodDto)
        {
            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(postMethodDto.Url);
            var result = httpClient.PostAsync(postMethodDto.Method, postMethodDto.BodyRequest).Result;
            if (result.StatusCode == HttpStatusCode.OK)
                return new PostMethodResultDto
                {
                    StatusCode = result.StatusCode,
                    ContentResult = ""
                };
            else
                return new PostMethodResultDto
                {
                    StatusCode = result.StatusCode,
                    ContentResult = "Problema na execução do método"
                };
        }
    }
}
