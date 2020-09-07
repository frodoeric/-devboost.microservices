using System.Net.Http;

namespace Integration.Pay.Dto
{
    public class PostMethodRequestDto
    {
        public PostMethodRequestDto(string url, string method, HttpContent bodyRequest)
        {
            Url = url;
            Method = method;
            BodyRequest = bodyRequest;
        }

        public string Url { get; private set; }
        public string Method { get; private set; }
        public HttpContent BodyRequest { get; private set; }
    }
}
