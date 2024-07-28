using Core.Application.CrossCuttingConcerns.Exceptions;
using Core.Application.Repositories.CategoryRepositories;
using Core.Application.Repositories.ProductRepositories;
using Core.Business.Messages.Exceptions;
using Core.Domain.Entities;

namespace Core.Business.BusinessRules
{
    public class ProductBusinessRules(IProductRepository productRepository,
                                      ICategoryRepository categoryRepository)
    {
        public async Task SameNameProductCanNotDuplicatedWhenInsert(string productName)
        {
            Product? product = await productRepository.FirstOrDefaultAsync(p => p.ProductName == productName);

            if (product != null)
                throw new BusinessException(ExceptionMessages.ProductAlreadyExists);
        }
        public async Task CheckCategoryExistsWhenProductInsert(int categoryId)
        {
            Category? category = await categoryRepository.FirstOrDefaultAsync(c => c.Id == categoryId);
            if (category == null)
                throw new BusinessException(ExceptionMessages.CategoryNotFound);
        }
        public async Task<Product> CheckProductExistsWhenModifyOrRemove(string name)
        {
            Product? product = await productRepository.FirstOrDefaultAsync(p => p.ProductName == name);
            if (product == null)
                throw new BusinessException(ExceptionMessages.ProductNotFound);

            return product;
        }
    }
}
