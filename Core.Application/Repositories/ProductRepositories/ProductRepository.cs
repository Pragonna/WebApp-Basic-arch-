using Core.Domain.Entities;
using Core.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Repositories.ProductRepositories
{
    public class ProductRepository:BaseRepository<Product,EFDbContext>,
                                   IProductRepository
    {
        public ProductRepository(EFDbContext context):base(context)
        {
        }
    }
}
