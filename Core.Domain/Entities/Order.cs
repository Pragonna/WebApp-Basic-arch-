using Core.Domain.Entities.Commons;

namespace Core.Domain.Entities
{
    public class Order : BaseEntity
    {
        public double Price { get; set; }
        public OrderDetails? OrderDetails { get; set; }
        public ICollection<Product> Products { get; set; }
        public Order()
        {
            Products = new HashSet<Product>();
            Price = Products.Select(x => x.Price).Sum();
        }
    }
}
