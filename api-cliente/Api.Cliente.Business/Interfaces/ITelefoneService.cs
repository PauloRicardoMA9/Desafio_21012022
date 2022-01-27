using Api.Cliente.Domain.Objetos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Cliente.Business.Interfaces
{
    public interface ITelefoneService : IDisposable
    {
        public Task<bool> Adicionar(Telefone telefone);
        public Task<IEnumerable<Telefone>> ObterTodos();
        public Task<Telefone> ObterPorId(Guid id);
        public Task<IEnumerable<Telefone>> ObterPorCliente(Guid idcCiente);
        public Task<bool> Atualizar(Telefone telefone);
        public Task<bool> Remover(Telefone telefone);
        public Task<bool> ClienteCadastrado(Guid idCliente);
        public Task<Telefone> ObterTelefoneCadastrado(Guid id);
    }
}
