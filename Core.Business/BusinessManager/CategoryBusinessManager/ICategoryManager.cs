using Core.Business.Dtos.CategoryDtos;
using Core.Domain.Entities;


namespace Core.Business.BusinessManager.CategoryBusinessManager
{
    public interface ICategoryManager
    {
        Task<CategoryAddOrUpdateDto> Add(CategoryAddOrUpdateDto categoryAddOrUpdateDto);
        Task<CategoryAddOrUpdateDto> Modify(string name);
        Task<CategoryAddOrUpdateDto> Remove(string name);
        Task<IEnumerable<CategoryListDto>> GetAll();
    }
}
