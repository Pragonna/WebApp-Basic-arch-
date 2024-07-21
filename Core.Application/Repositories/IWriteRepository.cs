using Core.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Repositories
{
    public interface IWriteRepository<TEntity>  where TEntity : BaseEntity
    {
        TEntity Add(TEntity entity);
        TEntity Delete(TEntity entity);
        TEntity Modify(TEntity entity);

        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TEntity entity);
        Task<TEntity> ModifyAsync(TEntity entity);
    }
}
