using Core.Domain.Entities;
using Core.Persistence.Context;
namespace Core.Application.Repositories.OrderRepositories
{
    public interface IOrderRepository:IWriteRepository<Order>,IReadRepository<Order>
    {
         EFDbContext Context { get; }
    }
}
