using System;

namespace Api.Cliente.Business.Interfaces
{
    public interface IClienteService : IDisposable
    {
        public bool Adicionar(Domain.Objetos.Cliente cliente);
    }
}
