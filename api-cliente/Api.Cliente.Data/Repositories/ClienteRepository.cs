using Api.Cliente.Data.Interfaces;

namespace Api.Cliente.Data.Repositories
{
    public class ClienteRepository : Repository<Domain.Objetos.Cliente>, IClienteRepository
    {
        public ClienteRepository(ClienteDbContext context) : base(context)
        {
        }
    }
}
