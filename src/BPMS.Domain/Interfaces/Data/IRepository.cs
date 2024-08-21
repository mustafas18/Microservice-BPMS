using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace BPMSDomain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> AddAsync(TEntity entity);
        Task AddRangeAsync(List<TEntity> entities);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "",
            int first = 0, int offset = 0);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null);
        TEntity LastOrDefault();
        IQueryable<TEntity> OrderBy(Expression<Func<TEntity, bool>> filter = null);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityName">includeProperties as string seperated by ,</param>
        /// <returns></returns>
        IQueryable<TEntity> Include([NotParameterized] string entityProperties);
        IQueryable<TEntity> AsNoTracking();
        Task<List<TEntity>> ListAsync();
        Task SaveChangesAsync();

    }
    }
