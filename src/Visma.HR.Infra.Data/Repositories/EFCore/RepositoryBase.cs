using Microsoft.EntityFrameworkCore;
using Visma.HR.Domain.Core.Interfaces.Repositories.Common;
using Visma.HR.Infra.Data.Contexts;

namespace Visma.HR.Infra.Data.Repositories.EFCore
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly HumanResourcesContext Context;
        private readonly DbSet<T> _dbSet;

        public RepositoryBase(HumanResourcesContext context)
        {
            Context = context;
            _dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            try
            {
                _dbSet.Add(entity);
            }
            catch
            {
                throw;
            }
        }

        public void Update(T entity)
        {
            try
            {
                _dbSet.Update(entity);
            }
            catch
            {
                throw;
            }
        }

        public void Remove(T entity)
        {
            try
            {
                _dbSet.Remove(entity);
            }
            catch
            {
                throw;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
