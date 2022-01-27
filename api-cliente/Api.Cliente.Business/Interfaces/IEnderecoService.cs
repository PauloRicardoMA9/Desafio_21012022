using Api.Cliente.Domain.Objetos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Cliente.Business.Interfaces
{
    public interface IEnderecoService : IDisposable
    {
        public Task<bool> Adicionar(Endereco endereco);
        public Task<IEnumerable<Endereco>> ObterTodos();
        public Task<Endereco> ObterPorId(Guid id);
        public Task<IEnumerable<Endereco>> ObterPorClienteId(Guid idcCiente);
        public Task<bool> Atualizar(Endereco endereco);
        public Task<bool> Remover(Endereco endereco);
        public Task<bool> ClienteCadastrado(Guid idCliente);
        public Task<Endereco> ObterEnderecoCadastrado(Guid id);
    }
}
