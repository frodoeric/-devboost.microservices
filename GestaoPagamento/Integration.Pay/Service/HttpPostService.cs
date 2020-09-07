using Integration.Pay.Dto;
using System;
using System.Net.Http;

namespace Integration.Pay.Service
{
    public static class HttpPostService
    {
        public static PostMethodResultDto HttpPost(PostMethodRequestDto postMethodDto)
        {
            using var httpClient = new HttpClient
            {
                BaseAddress = new Uri(postMethodDto.Url)
            };
            var result = httpClient.PostAsync(postMethodDto.Method, postMethodDto.BodyRequest).Result;
            return new PostMethodResultDto
            {
                StatusCode = result.StatusCode,
                ContentResult = result.Content.ReadAsStringAsync().Result
            };
        }
    }
}
