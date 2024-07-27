
using Core.Business.Dtos.ProductDtos;

namespace Core.Business.Dtos.OrderDtos
{
    public class OrderListDto
    {
        public int Id{ get; set; }
        public double Price { get; set; }
        public string ShippingAddress { get; set; }
        public string PostalCode { get; set; }
        public IList<ProductListDto> Products { get; set; }
        public OrderListDto()
        {
            Products = new List<ProductListDto>();
        }
    }
}
