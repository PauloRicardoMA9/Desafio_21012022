using Api.Cliente.Data.Interfaces;
using Api.Cliente.Domain.Objetos;
using System.Threading.Tasks;

namespace Api.Cliente.Data.Repositories
{
    public class TelefoneRepository : Repository<Telefone>, ITelefoneRepository
    {
        public TelefoneRepository(ClienteDbContext context) : base(context) { }
    }
}
