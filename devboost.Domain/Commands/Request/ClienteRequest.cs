namespace devboost.Domain.Commands.Request
{
    public class ClienteRequest
    {
        public string Nome { get; set; }
        public string EMail { get; set; }
        public string Telefone { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
