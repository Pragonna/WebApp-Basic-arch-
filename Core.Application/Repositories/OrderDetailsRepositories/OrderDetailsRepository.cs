using Core.Domain.Entities;
using Core.Persistence.Context;

namespace Core.Application.Repositories.OrderDetailsRepositories
{
    public class OrderDetailsRepository:BaseRepository<OrderDetails, EFDbContext>,IOrderDetailsRepository
    {
        public OrderDetailsRepository(EFDbContext context):base(context)
        {
        }
    }
}
