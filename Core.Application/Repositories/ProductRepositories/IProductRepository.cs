using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Repositories.ProductRepositories
{
    public interface IProductRepository : IWriteRepository<Product>, 
                                          IReadRepository<Product>
    {
    }
}
