using AutoMapper;
using Core.Application.Repositories.CategoryRepositories;
using Core.Business.BusinessRules;
using Core.Business.Dtos.CategoryDtos;
using Core.Domain.Entities;

namespace Core.Business.BusinessManager.CategoryBusinessManager
{
    public class CategoryManager(ICategoryRepository categoryRepository,
                                 CategoryBusinessRules categoryBusinessRules,
                                 IMapper mapper) : ICategoryManager
    {
        public async Task<CategoryListDto> Add(CategoryAddOrUpdateDto categoryAddOrUpdateDto)
        {
            await categoryBusinessRules.CategoryNameCanNotBeDuplicated(categoryAddOrUpdateDto.CategoryName);

            Category mappedCategory = mapper.Map<Category>(categoryAddOrUpdateDto);
            Category createdCategory = await categoryRepository.AddAsync(mappedCategory);
            return mapper.Map<CategoryListDto>(createdCategory);
        }

        public async Task<IEnumerable<CategoryListDto>> GetAll()
        {
            IEnumerable<Category> categories = categoryRepository.GetList().ToList();
            return mapper.Map<IEnumerable<CategoryListDto>>(categories);
        }

        public async Task<CategoryListDto> Remove(string name)
        {
           var category=await categoryBusinessRules.CheckCategoryExistsInDb(name);

            Category deletedCategory=await categoryRepository.DeleteAsync(category);
            return mapper.Map<CategoryListDto>(deletedCategory);
        }

        // .Modify
    }
}
