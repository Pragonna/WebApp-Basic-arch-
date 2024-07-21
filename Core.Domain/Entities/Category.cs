using Core.Domain.Entities.Commons;

namespace Core.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public string? CategoryDescription { get; set; } = string.Empty;
        public ICollection<Product> Products { get; set; }
        public Category()
        {
            Products = new HashSet<Product>();
        }
        public Category(int id, string name):this()
        {
            Id = id;
            CategoryName = name;
        }
    }
}
