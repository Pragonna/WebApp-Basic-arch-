using Core.Domain.Entities;
using Core.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Repositories.OrderRepositories
{
    public class OrderRepository:BaseRepository<Order,EFDbContext>, IOrderRepository
    {
        public OrderRepository(EFDbContext context):base(context)
        {
        }
    }
}
