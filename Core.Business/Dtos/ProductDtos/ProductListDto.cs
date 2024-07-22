
using Core.Domain.Entities;

namespace Core.Business.Dtos.ProductDtos
{
    public class ProductListDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }
}
