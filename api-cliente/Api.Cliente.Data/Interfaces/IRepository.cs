using Api.Cliente.Domain.Objetos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Api.Cliente.Data.Interfaces
{
    public interface IRepository<TEntidade> : IDisposable where TEntidade : Entidade
    {
        IUnitOfWork UnitOfWork { get; }
        void Adicionar(TEntidade entity);
        Task<TEntidade> ObterPorId(Guid id);
        Task<TEntidade> ObterPorIdAsNoTracking(Guid id);
        Task<List<TEntidade>> ObterTodos();
        void Atualizar(TEntidade entity);
        void Remover(Guid id);
        Task<IEnumerable<TEntidade>> Buscar(Expression<Func<TEntidade, bool>> predicate);
    }
}