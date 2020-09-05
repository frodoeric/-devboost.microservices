using System;
using System.Collections.Generic;

namespace devboost.Domain.Model
{
    public class Cliente
    {
        public Cliente(string nome, string eMail, string telefone, double latitude, double longitude)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            EMail = eMail;
            Telefone = telefone;
            Latitude = latitude;
            Longitude = longitude;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string EMail { get; set; }
        public string Telefone { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public List<Pedido> Pedidos { get; set; } = new List<Pedido>();

        public bool IsValid()
        {
            return
                !string.IsNullOrEmpty(Nome) &&
                !string.IsNullOrEmpty(EMail) &&
                !string.IsNullOrEmpty(Telefone);
        }
    }
}
