
using Core.Business.Dtos.ProductDtos;

namespace Core.Business.Dtos.OrderDtos
{
    public class OrderCreateDto
    {
        public double Price { get; set; }
        public string ShippingAddress { get; set; }
        public string PostalCode { get; set; }
        public IList<ProductListDto> Products{ get; set; }
        public OrderCreateDto()
        {
            Products = new List<ProductListDto>();
        }
    }
}
