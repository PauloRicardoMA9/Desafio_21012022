using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Cliente.Business.Interfaces
{
    public interface IClienteService : IDisposable
    {
        public Task<bool> Adicionar(Domain.Objetos.Cliente cliente);
        public Task<IEnumerable<Domain.Objetos.Cliente>> ObterTodos();
        public Task<Domain.Objetos.Cliente> ObterPorId(Guid id);
    }
}
