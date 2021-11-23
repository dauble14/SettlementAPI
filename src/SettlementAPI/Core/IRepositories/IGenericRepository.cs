using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SettlementAPI.Core.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        
        //Task<IEnumerable<T>> All();
        //Task<T> GetById(int id);
        //Task<bool> Add(T entity);
        //Task<bool> Delete(int id);
        //Task<bool> Upsert(T entity);
        
        Task<IList<T>> GetAll(
            Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            List<string> includes = null
        );
        Task Insert(T entity);
        Task<T> Get(Expression<Func<T, bool>> expression, List<string> inludes = null);
        Task InsertRange(IEnumerable<T> entities);
        Task Delete(int id);
        void DeleteRange(IEnumerable<T> entities);
        void Update(T entity);
    }
}
