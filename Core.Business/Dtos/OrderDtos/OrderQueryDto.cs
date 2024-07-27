using Core.Business.Dtos.ProductDtos;
using Core.Domain.Entities;
namespace Core.Business.Dtos.OrderDtos
{
    public class OrderQueryDto
    {
        public OrderDetailsDto OrderDetails{ get; set; }
        public ProductListDto Product{ get; set; }
    }
}
