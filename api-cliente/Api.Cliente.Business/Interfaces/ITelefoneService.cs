using Api.Cliente.Domain.Objetos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Cliente.Business.Interfaces
{
    public interface ITelefoneService : IDisposable
    {
        public Task<bool> Adicionar(Telefone telefone);
        public Task<bool> ClienteCadastrado(Guid idCliente);
        //public Task<IEnumerable<Telefone>> ObterTodos();
        //public Task<Telefone> ObterPorId(Guid id);
        //public Task<bool> ClienteCadastrado(Guid id);
        //public Task<bool> Atualizar(Telefone telefone);
        //public Task<bool> Remover(Guid id);
    }
}
