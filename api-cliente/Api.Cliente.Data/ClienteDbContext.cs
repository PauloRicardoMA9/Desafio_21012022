using Api.Cliente.Data.Interfaces;
using Api.Cliente.Domain.Objetos;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Cliente.Data
{
    public class ClienteDbContext : DbContext, IUnitOfWork
    {
        public ClienteDbContext(DbContextOptions<ClienteDbContext> options) : base(options) { }

        public DbSet<Domain.Objetos.Cliente> Clientes { get; set;}
        public DbSet<Telefone> Telefones { get; set;}
        public DbSet<Endereco> Enderecos { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder = MapearPropriedadesEsquecidas(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClienteDbContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }

        // Metodo para caso alguma propriedade de alguma entidade tiver sido esquecida de mapear, será mapeada do tipo varchar(100)
        private ModelBuilder MapearPropriedadesEsquecidas(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                entidade => entidade.GetProperties().Where(propriedade => propriedade.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            return modelBuilder;
        }
    }
}
