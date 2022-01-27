using Api.Cliente.Data.Interfaces;
using Api.Cliente.Domain.Objetos;

namespace Api.Cliente.Data.Repositories
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(ClienteDbContext context) : base(context) { }
    }
}
