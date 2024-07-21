using Core.Business.Dtos.ProductDtos;

namespace Core.Business.BusinessManager.ProductBusinessManager
{
    public interface IProductManager
    {
        Task<ProductAddDto> Add(ProductAddDto productAddOrUpdateDto);
        Task<ProductAddDto> Modify(string name);
        Task<ProductAddDto> Remove(string name);
        Task<IEnumerable<ProductListDto>> GetAll();
    }
}