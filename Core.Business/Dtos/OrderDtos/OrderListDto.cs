using Core.Domain.Entities;

namespace Core.Business.Dtos.OrderDtos
{
    public class OrderListDto
    {
        public int Id{ get; set; }
        public double Price { get; set; }
        public string ShippingAddress { get; set; }
        public string PostalCode { get; set; }
        public List<Product> Products { get; set; }
        public OrderListDto()
        {
            Products = new List<Product>();
        }
    }
}
