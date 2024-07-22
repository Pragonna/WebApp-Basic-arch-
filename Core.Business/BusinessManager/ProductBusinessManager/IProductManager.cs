using Core.Business.Dtos.CategoryDtos;
using Core.Business.Dtos.ProductDtos;

namespace Core.Business.BusinessManager.ProductBusinessManager
{
    public interface IProductManager
    {
        Task<ProductListDto> Add(ProductAddDto productAddOrUpdateDto);
        Task<ProductAddDto> Modify(string name);
        Task<ProductAddDto> Remove(string name);
        Task<IEnumerable<ProductListDto>> GetAll();
        Task<IEnumerable<ProductListDto>> GetByCategoryId(int categoryId);
    }
}