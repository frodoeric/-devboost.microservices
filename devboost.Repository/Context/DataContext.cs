using devboost.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace devboost.Repository.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Drone> Drone { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<PedidoDrone> PedidoDrone { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<PagamentoCartao> PagamentoCartao { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            DroneModel(builder);
            PedidoModel(builder);
            PedidoDroneModel(builder);
            UserModel(builder);
            ClienteModel(builder);
            PagamentoCartaoModel(builder);
        }

        void DroneModel(ModelBuilder builder)
        {
            builder.Entity<Drone>().HasKey(x => x.Id);
            builder.Entity<Drone>()
                .Property(x => x.StatusDrone)
                .HasColumnName("Status");
        }

        void PedidoModel(ModelBuilder builder)
        {
            builder.Entity<Pedido>()
                .HasKey(x => x.Id);

            builder.Entity<Pedido>()
                .Property(x => x.ClienteId)
                .HasColumnName("Client_Id");

            builder.Entity<Pedido>()
                .Property(x => x.PagamentoCartaoId)
                .HasColumnName("PagtoCartao_Id");

            builder.Entity<Pedido>()
                .HasOne(x => x.Cliente)
                .WithMany(x => x.Pedidos)
                .HasForeignKey(x => x.ClienteId);

            builder.Entity<Pedido>()
                .HasOne(x => x.PagamentoCartao)
                .WithMany(x => x.Pedidos)
                .HasForeignKey(x => x.PagamentoCartaoId);
        }

        void PedidoDroneModel(ModelBuilder builder)
        {
            builder.Entity<PedidoDrone>().ToTable("Pedido_Drone");

            builder.Entity<PedidoDrone>()
                .HasKey(x => new { x.PedidoId, x.DroneId });

            builder.Entity<PedidoDrone>()
                .Property(x => x.PedidoId)
                .HasColumnName("Pedido_Id");

            builder.Entity<PedidoDrone>()
                .Property(x => x.DroneId)
                .HasColumnName("Drone_Id");

            builder.Entity<PedidoDrone>()
                .HasOne(x => x.Pedido)
                .WithMany(x => x.PedidosDrones)
                .HasForeignKey(x => x.PedidoId);

            builder.Entity<PedidoDrone>()
                .HasOne(x => x.Drone)
                .WithMany(x => x.PedidosDrones)
                .HasForeignKey(x => x.DroneId);
        }

        void UserModel(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("Usuario");

            builder.Entity<User>()
                .HasKey(x => x.Id);

            builder.Entity<User>()
                .Property(x => x.Id)
                .HasColumnName("ID");

            builder.Entity<User>()
                .Property(x => x.UserName)
                .HasColumnName("Nome");

            builder.Entity<User>()
                .Property(x => x.Paswword)
                .HasColumnName("Senha");

            builder.Entity<User>()
                .Property(x => x.Role)
                .HasColumnName("Papel");
        }

        void ClienteModel(ModelBuilder builder)
        {
            builder.Entity<Cliente>().ToTable("Cliente");
            
            builder.Entity<Cliente>()
                .HasKey(x => x.Id);

            builder.Entity<Cliente>()
                .Property(x => x.Id)
                .HasColumnName("ID");

            builder.Entity<Cliente>()
                .Property(x => x.Nome)
                .HasColumnName("Nome");

            builder.Entity<Cliente>()
                .Property(x => x.EMail)
                .HasColumnName("email");

            builder.Entity<Cliente>()
                .Property(x => x.Telefone)
                .HasColumnName("telefone");

            builder.Entity<Cliente>()
                .Property(x => x.Latitude)
                .HasColumnName("Latitude");

            builder.Entity<Cliente>()
                .Property(x => x.Longitude)
                .HasColumnName("Longitude");

            builder.Entity<Cliente>()
                .Property(x => x.UserId)
                .HasColumnName("Usuario_Id");

            builder.Entity<Cliente>()
                .HasOne(x => x.User)
                .WithOne(x => x.Cliente);
        }

        void PagamentoCartaoModel(ModelBuilder builder)
        {
            builder.Entity<PagamentoCartao>().ToTable("PagamentoCartao");

            builder.Entity<PagamentoCartao>()
                .HasKey(x => x.Id);

            builder.Entity<PagamentoCartao>()
                .Property(x => x.Bandeira)
                .HasColumnName("Bandeira");

            builder.Entity<PagamentoCartao>()
                .Property(x => x.Numero)
                .HasColumnName("Numero");

            builder.Entity<PagamentoCartao>()
                .Property(x => x.Vencimento)
                .HasColumnName("Vencimento");

            builder.Entity<PagamentoCartao>()
                .Property(x => x.CodigoSeguranca)
                .HasColumnName("CodigoSeguranca");

            builder.Entity<PagamentoCartao>()
                .Property(x => x.Valor)
                .HasColumnName("Valor");

            builder.Entity<PagamentoCartao>()
                .Property(x => x.Status)
                .HasColumnName("Status");
        }
    }
}
