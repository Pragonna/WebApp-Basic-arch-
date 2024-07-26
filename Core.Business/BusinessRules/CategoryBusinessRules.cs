using Core.Application.Repositories.CategoryRepositories;
using Core.Domain.Entities;

namespace Core.Business.BusinessRules
{
    public class CategoryBusinessRules(ICategoryRepository categoryRepository)
    {
        public async Task CategoryNameCanNotBeDuplicated(string categoryName)
        {
            Category category = await categoryRepository.FirstOrDefaultAsync(c => c.CategoryName == categoryName);
            if (category != null)
                throw new Exception("this category already is exist");
        }
        public async Task<Category> CheckCategoryExistsInDb(string name)
        {
            var categories = categoryRepository.GetList(c => c.CategoryName == name);
            if (!categories.Any())
                throw new Exception("this category is not exists");

            return categories.First();
        }
    }
}
