using Core.Business.Dtos.OrderDtos;

namespace Core.Business.BusinessManager.OrderBusinessManager
{
    public interface IOrderManager
    {
        Task<OrderListDto> CreateOrder(OrderCreateDto orderCreateDto);
        Task<IEnumerable<OrderListDto>> GetAllOrders();
    }
}