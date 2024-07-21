using Core.Domain.Entities.Commons;

namespace Core.Domain.Entities
{
    public class OrderDetails : BaseEntity
    {
        public string ShippingAddress { get; set; }
        public int OrderId{ get; set; }
        public string PostalCode { get; set; }
        public Order Order { get; set; }
        public OrderDetails(int id, string shippingAddress, string postalCode, int orderId) : base(id)
        {
            ShippingAddress = shippingAddress;
            PostalCode = postalCode;
            OrderId = orderId;
        }
    }
}
