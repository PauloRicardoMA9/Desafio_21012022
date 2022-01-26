using System;
using System.Threading.Tasks;

namespace Api.Cliente.Business.Interfaces
{
    public interface IClienteService : IDisposable
    {
        public Task<bool> Adicionar(Domain.Objetos.Cliente cliente);
    }
}
