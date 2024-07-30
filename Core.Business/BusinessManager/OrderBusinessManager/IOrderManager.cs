using Core.Business.Dtos.OrderDtos;
using Microsoft.AspNetCore.Mvc;

namespace Core.Business.BusinessManager.OrderBusinessManager
{
    public interface IOrderManager
    {
        Task<IActionResult> CreateOrder(OrderCreateDto orderCreateDto);
        Task<IActionResult> GetAllOrders();
    }
}