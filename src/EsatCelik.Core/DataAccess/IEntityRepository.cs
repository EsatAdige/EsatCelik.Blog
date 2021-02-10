using EsatCelik.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EsatCelik.Core.DataAccess
{
    public interface IEntityRepository<TEntity> where TEntity : class, IEntity
    {
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "");

        Task<ICollection<TEntity>> GetListAsync(List<Expression<Func<TEntity, bool>>> filters = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        Task<int> CommitAsync();

        Task Dispose();
    }
}
