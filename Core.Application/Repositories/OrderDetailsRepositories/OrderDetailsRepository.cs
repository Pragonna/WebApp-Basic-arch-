using Core.Domain.Entities;
using Core.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Repositories.OrderDetailsRepositories
{
    public class OrderDetailsRepository:BaseRepository<Order,EFDbContext>,IOrderDetailsRepository
    {
        public OrderDetailsRepository(EFDbContext context):base(context)
        {
        }
    }
}
