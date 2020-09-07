using System.Net;

namespace Integration.Pay.Dto
{
    public class PostMethodResultDto
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ContentResult { get; set; }

    }
}
