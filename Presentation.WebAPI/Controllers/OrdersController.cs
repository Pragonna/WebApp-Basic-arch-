using Core.Business.BusinessManager.OrderBusinessManager;
using Core.Business.Dtos.OrderDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "OnlyUser")]
    public class OrdersController(IOrderManager orderManager) : ControllerBase
    {
        [HttpPost("post")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderCreateDto orderCreateDto)
            => await orderManager.CreateOrder(orderCreateDto);
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllOrders()
            => await orderManager.GetAllOrders();
    }
}
