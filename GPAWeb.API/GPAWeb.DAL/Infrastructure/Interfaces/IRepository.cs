using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GPAWeb.DAL.Infrastructure.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<List<TEntity>> AddRangeAsync(List<TEntity> entity);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null, CancellationToken cancellationToken = default);
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null, CancellationToken cancellationToken = default);
        EntityState Update(TEntity entity);
        EntityState Delete(TEntity entity);
        bool IsExists(TEntity entity);
    }
}
