using Core.Business.Dtos.CategoryDtos;


namespace Core.Business.BusinessManager.CategoryBusinessManager
{
    public interface ICategoryManager
    {
        Task<CategoryListDto> Add(CategoryAddOrUpdateDto categoryAddOrUpdateDto);
        Task<CategoryAddOrUpdateDto> Modify(string name);
        Task<CategoryAddOrUpdateDto> Remove(string name);
        Task<IEnumerable<CategoryListDto>> GetAll();
    }
}
