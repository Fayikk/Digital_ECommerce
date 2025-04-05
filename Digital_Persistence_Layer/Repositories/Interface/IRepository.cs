using Digital_Domain_Layer.Extensions;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Persistence_Layer.Repositories.Interface
{
    public interface IRepository<T> where T : new()
    {
        Task<T> GetById(Guid id);
        Task<T> GetByIdGeneric<T>(Guid id) where T : class;
        Task<T> GetWhereWithThenInclude(Expression<Func<T, bool>> filter = null,Func<IQueryable<T>,IIncludableQueryable<T,object>> include = null);
         Task<bool> IsAnyItem(Expression<Func<T, bool>> filter = null);
        Task<IEnumerable<T>> GetAll();
        Task<List<T>> GetAllWhere(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        Task<T> Add(T entity);
        Task<List<T>> AddRange(List<T> entities);
        Task<T> GetWhere(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeProperties);
        Task<T> Update(Guid Id,T entity);
        Task Delete(Guid id);
        Task<PagedResult<T>> GetPagedResult(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            int pageNumber = 1, int pageSize = 10, params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>> GetWithIncludeProperties(params Expression<Func<T, object>>[] includeProperties);
    }
}
