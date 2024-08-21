using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Collections;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using BPMSDomain.Interfaces;

namespace BPMSDomain.Infrastructure
{
    public class Repository<TEntity>:IRepository<TEntity> where TEntity:class
    {

    
        private readonly BpmsDbContext _context;
        public Repository(BpmsDbContext context)
        {
            _context = context;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
           return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }
        public async Task<TEntity> Add(TEntity entity,bool saveChanges=true)
        {
            var  createdEntity= _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return createdEntity.Entity;  
        }

        public async Task<TEntity>  AddAsync(TEntity entity)
        {
            var createdEntity = await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return createdEntity.Entity;
        }

        public async Task AddRangeAsync(List<TEntity> entities)
        {
            await _context.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(TEntity entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
           var updatedEntity = _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
            return updatedEntity.Entity;
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> filter = null,
                            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                            string includeProperties = "",
                            int first = 0, int offset = 0)
        {
            if (filter != null)
            {
                return _context.Set<TEntity>().Where(filter);
            }
            return null;


        }
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter != null)
            {
                return _context.Set<TEntity>().FirstOrDefault(filter);
            }
            return _context.Set<TEntity>().FirstOrDefault();
        }
        public IQueryable<TEntity> OrderBy(Expression<Func<TEntity, bool>> filter = null)
        {
            return _context.Set<TEntity>().OrderBy(filter);
        }
        public TEntity LastOrDefault()
        {
            return _context.Set<TEntity>().LastOrDefault();
        }

        public IQueryable<TEntity> Include([NotParameterized] string entityProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            foreach (var includeProperty in entityProperties.Split(",", StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public IQueryable<TEntity> AsNoTracking()
        {
            return _context.Set<TEntity>().AsNoTracking();
        }


        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }


        public Task<List<TEntity>> ListAsync()
        {
            return _context.Set<TEntity>().ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
