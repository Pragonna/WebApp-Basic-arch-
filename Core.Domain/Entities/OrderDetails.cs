using Core.Domain.Entities.Commons;

namespace Core.Domain.Entities
{
    public class OrderDetails : BaseEntity
    {
        public double Price { get; set; }
        public string ShippingAddress { get; set; }
        public string PostalCode { get; set; }

        public OrderDetails(double price, string shippingAddress, string postalCode) : this()
        {
            Price = price;
            ShippingAddress = shippingAddress;
            PostalCode = postalCode;
        }

        public OrderDetails()
        {
        }
        
    }
}
