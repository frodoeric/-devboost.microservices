using System.Net.Http;

namespace Integration.Pay.Dto
{
    public class PostMethodRequestDto
    {
        public string Url { get; set; }
        public string Method { get; set; }
        public HttpContent BodyRequest { get; set; }
    }
}
