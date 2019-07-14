using Enterprise_Resource_planning.Models.CenDek;
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
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        TEntity GetOne(Func<TEntity, bool> predicate);
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
        static int a = 0;
        public async Task Update(TEntity item)
        {
            if (a == 1)
            {
                _context.Entry(item).State = EntityState.Detached;
            }
            else if (a == 0)
            {
                // If first time to by UPDATE
                _context.Entry(item).State = EntityState.Modified;
            }

            a++;
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

            return await _dbSet.Take(id).AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<TEntity>> Skip(int id)
        {

            return await _dbSet.Skip(id).AsNoTracking().ToListAsync();
        }
        #endregion
        #region Get _dbSet
        //Get one,  ----one table
        public TEntity GetOne(Func<TEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).FirstOrDefault();
        }

        //Get Table => Table.(..),  ----where predicate Ids exist in table
        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        //Get All,  ----all tables
        public IEnumerable<TEntity> Get()
        {
            return _dbSet.AsNoTracking().ToList();
        }
        #endregion

        #region Includes Forign Tables
        // Get All, p => p.(FK Table) Includes FK table
        public async Task<IEnumerable<TEntity>> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await Include(includeProperties).AsNoTracking().ToListAsync();
        }
        // Get All, p => p.(FK Table) Includes FK table
        public IEnumerable<TEntity> GetWithIncludes(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Include(includeProperties).AsNoTracking().ToList();
        }
        // Get Table => Table.(..),p => p.(FK Table) Includes FK table
        public IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.AsNoTracking().Where(predicate).ToList();
        }
        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
        #endregion
    }

}