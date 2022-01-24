using Api.Cliente.Domain.Objetos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Cliente.Data.Mapeamentos
{
    public class MapeamentoEndereco : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(endereco => endereco.Id);

            builder.Property(endereco => endereco.Logradouro)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(endereco => endereco.Numero)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.Property(endereco => endereco.Bairro)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(endereco => endereco.Cidade)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(endereco => endereco.Estado)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(endereco => endereco.Principal)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.ToTable("Enderecos");
        }
    }
}
