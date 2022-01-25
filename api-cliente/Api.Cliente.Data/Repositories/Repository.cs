using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Api.Cliente.Data;
using Api.Cliente.Data.Interfaces;
using Api.Cliente.Domain.Objetos;
using Microsoft.EntityFrameworkCore;

namespace ma9.Data.Repository
{
    public abstract class Repository<TEntidade> : IRepository<TEntidade> where TEntidade : Entidade, new()
    {
        protected readonly ClienteDbContext Db;
        protected readonly DbSet<TEntidade> DbSet;

        protected Repository(ClienteDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntidade>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public virtual void Adicionar(TEntidade entity)
        {
            DbSet.Add(entity);
        }

        public async Task<IEnumerable<TEntidade>> Buscar(Expression<Func<TEntidade, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntidade> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntidade>> ObterTodos()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public virtual void Atualizar(TEntidade entity)
        {
            DbSet.Update(entity);
        }

        public virtual void Remover(Guid id)
        {
            DbSet.Remove(new TEntidade { Id = id });
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}