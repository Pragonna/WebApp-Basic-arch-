using Core.Business.BusinessManager.OrderBusinessManager;
using Core.Business.Dtos.OrderDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(policy: "OnlyUser")]
    public class OrdersController(IOrderManager orderManager) : ControllerBase
    {
        [HttpPost("post")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderAddDto orderAddDto)
        {
            var result = await orderManager.CreateOrder(orderAddDto);
            return Ok(result);
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetList()
        {
            var result = orderManager.ListOrders();
            return Ok(result);
        }
    }
}
