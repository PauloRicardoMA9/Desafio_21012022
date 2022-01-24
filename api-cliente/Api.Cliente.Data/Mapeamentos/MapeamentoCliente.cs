using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Api.Cliente.Data.Mapeamentos
{
    public class MapeamentoCliente : IEntityTypeConfiguration<Domain.Objetos.Cliente>
    {
        public void Configure(EntityTypeBuilder<Domain.Objetos.Cliente> builder)
        {
            builder.HasKey(cliente => cliente.Id);

            builder.Property(cliente => cliente.Nome)
                .IsRequired()
                .HasColumnType("varchar(60)");

            builder.Property(cliente => cliente.Cpf)
                .IsRequired()
                .HasColumnType("varchar(11)");

            builder.Property(cliente => cliente.Sexo)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(cliente => cliente.Email)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.HasMany(cliente => cliente.Telefones)
                .WithOne(telefone => telefone.Cliente)
                .HasForeignKey(telefone => telefone.IdCliente);

            builder.HasMany(cliente => cliente.Enderecos)
                .WithOne(endereco => endereco.Cliente)
                .HasForeignKey(endereco => endereco.IdCliente);

            builder.ToTable("Clientes");
        }
    }
}
