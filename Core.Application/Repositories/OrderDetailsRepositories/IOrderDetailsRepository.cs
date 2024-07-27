using Core.Domain.Entities;

namespace Core.Application.Repositories.OrderDetailsRepositories
{
    public interface IOrderDetailsRepository:IWriteRepository<OrderDetails>,IReadRepository<OrderDetails>
    {
    }
}
