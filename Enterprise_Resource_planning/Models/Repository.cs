using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Enterprise_Resource_planning.Models
{
    public interface IGenericRepository<TEntity>
    {
        Task<TEntity> FindById(int id);
        Task<IEnumerable<TEntity>> Get();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        Task Create(TEntity item);
        Task Remove(TEntity item);
        Task Update(TEntity item);
    }
    public class Repository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        DbContext _context;
        DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        #region Create, Update, Remove, Find
        public async Task<TEntity> FindById(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task Create(TEntity item)
        {
            _dbSet.Add(item);
            await _context.SaveChangesAsync();
        }
        public async Task Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task Remove(TEntity item)
        {
            _context.Entry(item).State = EntityState.Deleted;
            _dbSet.Attach(item);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveRange(List<TEntity> items)
        {
            foreach (var item in items)
            {
                _context.Entry(item).State = EntityState.Deleted;
            }
            await _context.SaveChangesAsync();
        }
        #endregion
        #region Take and Skip
        public async Task<IEnumerable<TEntity>> Take(int id)
        {

            return await _dbSet.Take(id).ToListAsync();
        }
        public async Task<IEnumerable<TEntity>> Skip(int id)
        {

            return await _dbSet.Skip(id).ToListAsync();
        }
        #endregion
        #region Get _dbSet
        //Get All,  ----one table
        public async Task<IEnumerable<TEntity>> Get()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }
        //Get Table => Table.(..),  ----one table
        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }


        // Get All, p => p.(FK Table) Includes FK table
        public async Task<IEnumerable<TEntity>> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await Include(includeProperties).ToListAsync();
        }
        // Get All, p => p.(FK Table) Includes FK table
        public IEnumerable<TEntity> GetWithIncludes(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }
        // Get Table => Table.(..),p => p.(FK Table) Includes FK table
        public IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.AsNoTracking().Where(predicate).ToList();
        }
        #endregion
        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }

}