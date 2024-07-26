using Core.Domain.Entities.Commons;

namespace Core.Domain.Entities
{
    public class Product : BaseEntity
    {

        public string ProductName { get; set; }
        public int CategoryId{ get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public Category Category  { get; set; }
        public Product()
        {
        }
        public Product(
            int id,
            string productName,
            double price,
            int stock,
            int categoryId)
            : base(id)
        {
            ProductName = productName;
            Price = price;
            Stock = stock;
            CategoryId = categoryId;
        }

    }
}
