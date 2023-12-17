using GPAWeb.DAL.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GPAWeb.DAL.Infrastructure
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;

        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;

            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            return (await _dbSet.AddAsync(entity)).Entity;
        }

        public async Task<List<TEntity>> AddRangeAsync(List<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return entities;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null, CancellationToken cancellationToken = default)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(filter, cancellationToken);
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null, CancellationToken cancellationToken = default)
        {
            return await (filter == null ? _dbSet.ToListAsync(cancellationToken) : _dbSet.Where(filter).ToListAsync(cancellationToken));
        }

        public EntityState Update(TEntity entity)
        {
            return _dbSet.Update(entity).State;
        }

        public EntityState Delete(TEntity entity)
        {
            return _dbSet.Remove(entity).State;
        }

        public bool IsExists(TEntity entity)
        {
            return  (_dbSet.Find(entity) != null) ? true : false;
        }
    }
}
