﻿using Microsoft.EntityFrameworkCore;
using Visma.Domain.Core.Interfaces.Repositories.Common;
using Visma.Infra.Data.Contexts;

namespace Visma.Infra.Data.Repositories.EFCore
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly CoreContext Context;
        private readonly DbSet<T> _dbSet;

        public RepositoryBase(CoreContext context)
        {
            Context = context;
            _dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            try
            {

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
