using Core.Business.Dtos.ProductDtos;

namespace Core.Business.BusinessManager.ProductBusinessManager
{
    public interface IProductManager
    {
        Task<ProductListDto> Add(ProductAddDto productAddOrUpdateDto);
        Task<ProductListDto> Modify(ProductUpdateDto productUpdateDto);
        Task<ProductListDto> Remove(string name);
        Task<IEnumerable<ProductListDto>> GetAll();
        Task<IEnumerable<ProductListDto>> GetByCategoryId(int categoryId);
    }
}