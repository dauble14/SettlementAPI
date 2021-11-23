using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SettlementAPI.Core.IRepositories;
using SettlementAPI.Entities;

namespace SettlementAPI.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected SettlementDbContext _context;
        protected DbSet<T> _dbSet;
        protected readonly ILogger _logger;
        public GenericRepository(SettlementDbContext context, 
            ILogger logger)
        {
            _context = context;
            _logger = logger;
            _dbSet=context.Set<T>();
        }

        public virtual async Task<IList<T>> GetAll(
            Expression<Func<T, bool>> expression = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            List<string> includes = null
            )
        {
            IQueryable<T> query = _dbSet;
            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (includes != null)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> Get(
            Expression<Func<T, bool>> expression, 
            List<string> includes = null
            )
        {
            IQueryable<T> query = _dbSet;
            if (includes != null)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public virtual async Task InsertRange(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public virtual async Task Delete(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
        }

        public virtual void DeleteRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual async Task Insert(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
    }
}
