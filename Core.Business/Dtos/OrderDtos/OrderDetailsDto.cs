

namespace Core.Business.Dtos.OrderDtos
{
    public class OrderDetailsDto
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string ShippingAddress { get; set; }
        public string PostalCode { get; set; }
    }
}
