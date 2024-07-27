using Core.Domain.Entities;
using Core.Persistence.Context;

namespace Core.Application.Repositories.OrderRepositories
{
    public class OrderRepository:BaseRepository<Order,EFDbContext>, IOrderRepository
    {
        private readonly EFDbContext context;
        public EFDbContext Context => context;

        public OrderRepository(EFDbContext context):base(context)
        {
            this.context = context;
        }
       
       
    }
}
