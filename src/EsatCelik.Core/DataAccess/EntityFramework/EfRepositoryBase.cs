using EsatCelik.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EsatCelik.Core.DataAccess.EntityFramework
{
    public class EfRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        private readonly TContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public EfRepositoryBase(TContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            try
            {
                var addedEntity = _context.Entry(entity);
                addedEntity.State = EntityState.Added;
                return entity;
            }
            catch (Exception e)
            {
                await this.Dispose();
                throw;
            }
        }

        public async Task<int> CommitAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                await this.Dispose();
                throw;
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {
            try
            {
                var deleteEntity = _context.Entry(entity);
                deleteEntity.State = EntityState.Deleted;
            }
            catch (Exception ex)
            {
                await this.Dispose();
                throw;
            }
        }

        public async Task Dispose()
        {
            await _context.DisposeAsync();
            GC.SuppressFinalize((this));
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return await query.SingleOrDefaultAsync();
        }

        public async Task<ICollection<TEntity>> GetListAsync(List<Expression<Func<TEntity, bool>>> filters = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filters != null)
            {
                foreach (var expression in filters)
                {
                    query = query.Where(expression);
                }
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            try
            {
                var updatetedEntity = _context.Entry(entity);
                updatetedEntity.State = EntityState.Modified;
                return entity;
            }
            catch (Exception e)
            {
                await this.Dispose();
                throw;
            }
        }
    }
}
