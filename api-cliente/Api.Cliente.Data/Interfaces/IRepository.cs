using Api.Cliente.Domain.Objetos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Api.Cliente.Data.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entidade
    {
        IUnitOfWork UnitOfWork { get; }
        void Adicionar(TEntity entity);
        Task<TEntity> ObterPorId(Guid id);
        Task<List<TEntity>> ObterTodos();
        void Atualizar(TEntity entity);
        void Remover(Guid id);
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
    }
}