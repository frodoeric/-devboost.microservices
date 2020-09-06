using Domain.Pay.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Pay.Mappings
{
    public class PaymentMapping : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id);
            builder.Property(u => u.Status);
            builder.Property(u => u.Name).HasColumnName("Nome").HasMaxLength(140);
            builder.Property(u => u.NumeroCartao).HasMaxLength(16);
            builder.Property(u => u.PayId);
            builder.Property(u => u.Valor);
            builder.Property(u => u.Vencimento);
            builder.Property(u => u.CodigoSeguranca);
            builder.Property(u => u.Bandeira).HasMaxLength(30);
            builder.Property(u => u.CreatedAt);
        }
    }
}
