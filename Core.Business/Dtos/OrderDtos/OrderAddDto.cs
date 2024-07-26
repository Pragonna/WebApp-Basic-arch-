
using Core.Business.Dtos.ProductDtos;
using Core.Domain.Entities;

namespace Core.Business.Dtos.OrderDtos
{
    public class OrderAddDto
    {
        public double Price{ get; set; }
        public string ShippingAddress { get; set; }
        public string PostalCode { get; set; }
        public ICollection<ProductListDto>Products { get; set; }
    }
}
