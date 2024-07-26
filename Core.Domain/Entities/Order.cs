using Core.Domain.Entities.Commons;

namespace Core.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public Order(int orderId, int productId) : this()
        {
            OrderId = orderId;
            ProductId = productId;
        }
        public Order()
        {
        }
    }
}
