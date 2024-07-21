

using Core.Application.Repositories.CategoryRepositories;
using Core.Domain.Entities;

namespace Core.Business.BusinessRules
{
    public class CategoryBusinessRules(ICategoryRepository categoryRepository)
    {
        public async Task CategoryNameCanNotBeDuplicated(string categoryName)
        {
           Category category=await categoryRepository.FirstOrDefaultAsync(c => c.CategoryName == categoryName);
            if (category != null)
                throw new Exception("this category already is exist");
        }
    }
}
