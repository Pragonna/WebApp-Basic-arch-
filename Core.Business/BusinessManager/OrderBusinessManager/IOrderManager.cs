using Core.Business.Dtos.OrderDtos;

namespace Core.Business.BusinessManager.OrderBusinessManager
{
    public interface IOrderManager
    {
        Task<OrderListDto> CreateOrder(OrderAddDto orderAddDto);
        IEnumerable<OrderListDto> ListOrders();
    }
}