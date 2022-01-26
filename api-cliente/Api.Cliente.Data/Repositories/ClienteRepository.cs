using Api.Cliente.Data.Interfaces;
using System.Threading.Tasks;

namespace Api.Cliente.Data.Repositories
{
    public class ClienteRepository : Repository<Domain.Objetos.Cliente>, IClienteRepository
    {
        public ClienteRepository(ClienteDbContext context) : base(context) { }
    }
}
