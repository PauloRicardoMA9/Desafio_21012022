using Api.Cliente.Domain.Objetos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Cliente.Data.Mapeamentos
{
    public class MapeamentoTelefone : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.HasKey(telefone => telefone.Id);

            builder.Property(telefone => telefone.Ddd)
                .IsRequired()
                .HasColumnType("varchar(2)");

            builder.Property(telefone => telefone.Numero)
                .IsRequired()
                .HasColumnType("varchar(9)");

            builder.Property(telefone => telefone.Principal)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.ToTable("Telefones");
        }
    }
}
