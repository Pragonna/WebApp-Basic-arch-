using Core.Business.Dtos.CategoryDtos;


namespace Core.Business.BusinessManager.CategoryBusinessManager
{
    public interface ICategoryManager
    {
        Task<CategoryListDto> Add(CategoryAddOrUpdateDto categoryAddOrUpdateDto);
        Task<CategoryListDto> Remove(string name);
        Task<IEnumerable<CategoryListDto>> GetAll();
    }
}
