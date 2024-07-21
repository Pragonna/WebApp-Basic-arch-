using Core.Domain.Entities;
using Core.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Repositories.CategoryRepositories
{
    public class CategoryRepository:BaseRepository<Category,EFDbContext>, ICategoryRepository
    {
        public CategoryRepository(EFDbContext context):base(context)
        {
        }
    }
}
