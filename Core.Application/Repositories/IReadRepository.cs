using Core.Domain.Entities.Commons;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Application.Repositories
{
    public interface IReadRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetList(Expression<Func<TEntity, bool>>? predicate = null,
                                    Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>?
                                                           include = null);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        TEntity GetById(int id);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetByIdAsync(int id);

    }
}
