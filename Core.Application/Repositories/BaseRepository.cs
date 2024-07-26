using Core.Domain.Entities.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Application.Repositories
{
    public class BaseRepository<TEntity, TContext> :
        IWriteRepository<TEntity>,
        IReadRepository<TEntity>
        where TEntity : BaseEntity
        where TContext : DbContext

    {
        protected TContext Context { get; }

        public BaseRepository(TContext context)
        {
            Context = context;
        }

        public TEntity Add(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            Context.SaveChanges();
            return entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            await Context.SaveChangesAsync();
            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            Context.SaveChanges();
            return entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            await Context.SaveChangesAsync();
            return entity;
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public TEntity GetById(int id)
        {
            return FirstOrDefault(c => c.Id == id);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await FirstOrDefaultAsync(c => c.Id == id);
        }

        public IQueryable<TEntity> GetList(Expression<Func<TEntity, bool>>? predicate = null,
                                           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>?
                                                           include = null)
        {
            IQueryable<TEntity> queryable = Context.Set<TEntity>();
            if (include != null) queryable = include(queryable);
            if (predicate != null) queryable = queryable.Where(predicate);

            return queryable;
        }

        public TEntity Modify(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
            return entity;
        }

        public async Task<TEntity> ModifyAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return entity;
        }
    }
}
