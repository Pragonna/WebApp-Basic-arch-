

using Core.Application.CrossCuttingConcerns.Exceptions;
using Core.Application.Repositories.CategoryRepositories;
using Core.Business.Messages.Exceptions;
using Core.Domain.Entities;

namespace Core.Business.BusinessRules
{
    public class CategoryBusinessRules(ICategoryRepository categoryRepository)
    {
        public async Task CategoryNameCanNotBeDuplicated(string categoryName)
        {
           Category category=await categoryRepository.FirstOrDefaultAsync(c => c.CategoryName == categoryName);
            if (category != null)
                throw new BusinessException(ExceptionMessages.CategoryAlreadyExists);
        }
    }
}
