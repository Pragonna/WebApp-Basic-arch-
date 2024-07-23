using Core.Application.Repositories.CategoryRepositories;
using Core.Application.Repositories.ProductRepositories;
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
                throw new Exception("This Product already exist.");
        }
        public async Task CheckCategoryExistsWhenProductInsert(int categoryId)
        {
            Category? category = await categoryRepository.FirstOrDefaultAsync(c => c.Id == categoryId);
            if (category == null)
                throw new Exception("this category is not exists");
        }
        public async Task<Product> CheckProductExistsWhenModifyOrRemove(string name)
        {
            Product? product = await productRepository.FirstOrDefaultAsync(p => p.ProductName == name);
            if (product == null)
                throw new Exception("This product is not exists");

            return product;
        }
    }
}
