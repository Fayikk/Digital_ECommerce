using Digital_Domain_Layer.Extensions;
using Digital_Persistence_Layer.AppDbContext;
using Digital_Persistence_Layer.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Persistence_Layer.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly ApplicationDbContext _context;
        public Repository(ApplicationDbContext context)
        {
            _context = context; 
        }

        public DbSet<T> Table { get => _context.Set<T>(); }

        public async Task<T> Add(T entity)
        {
            await Table.AddAsync(entity);
            
            if(await _context.SaveChangesAsync() > 0)
            {
                return entity;
            }
            
            return null;
        }

        public async Task<List<T>> AddRange(List<T> entities)
        {
            await Table.AddRangeAsync(entities);

            if (await _context.SaveChangesAsync() > 0)
            {
                return entities;
            }

            return null;
        }

        public async Task Delete(Guid id)
        {
            var entity = await Table.FindAsync(id);
            if (entity != null)
            {
                Table.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
           IEnumerable<T> entities = await Table.ToListAsync();
            if (entities is not null)
            {
                return entities;
            }
            return null;
        }

        public async Task<List<T>> GetAllWhere(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = Table.AsQueryable();
            if (filter is not null)
            {
                query = query.Where(filter);
            }
            if (include is not null)
            {
                query = include(query);
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            var entity = await Table.FindAsync(id);
            if (entity != null)
            {
                return entity;
            }
            return null;
        }

        public async Task<T> GetByIdGeneric<T>(Guid id) where T : class
        {
            var entity = await _context.Set<T>().FindAsync(id);
            return entity ?? null;
        }

        public async Task<PagedResult<T>> GetPagedResult(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int pageNumber = 1, int pageSize = 10, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table.AsQueryable();
            if (filter is not null)
            {
                query = query.Where(filter);
            }
            int totalCount = await query.CountAsync();
            if(orderBy is not null)
            {
                query = orderBy(query);
            }
            if (includeProperties.Length > 0)
            {
                foreach (var item in includeProperties)
                {
                    query = query.Include(item);
                }
            }
            List<T> items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PagedResult<T>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

        }
        public async Task<T> GetWhere(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table.AsQueryable();
            if (filter is not null)
            {
                query = query.Where(filter);
            }
            if (includeProperties.Length > 0)
            {
                foreach (var item in includeProperties)
                {
                    query = query.Include(item);
                }
            }

            return query.FirstOrDefaultAsync().Result;
        }

        public async Task<T> GetWhereWithThenInclude(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = Table.AsQueryable();
            if (filter is not null)
            {
                query = query.Where(filter);
            }
            if (include is not null)
            {
                query = include(query);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetWithIncludeProperties(params Expression<Func<T, object>>[] includeProperties)
        {
            var query = Table.AsQueryable();    
            if (includeProperties.Length>0)
            {
                foreach (var item in includeProperties)
                {
                    query = query.Include(item);
                }
            }
            return query.AsEnumerable();
        }

        public Task<bool> IsAnyItem(Expression<Func<T, bool>> filter = null)
        {

            IQueryable<T> query = Table.AsQueryable();
            if (filter is not null)
            {
                query = query.Where(filter);
            }
            return query.AnyAsync();
        }

        public async Task<T> Update(Guid Id,T entity)
        {
            var existingEntity = await Table.FindAsync(Id);
            if (existingEntity != null)
            {
                Table.Entry(existingEntity).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            return null;
        }
    }
}
