
namespace Core.Business.Dtos.CategoryDtos
{
    public class CategoryAddOrUpdateDto
    {
        public string CategoryName { get; set; }
        public string? CategoryDescription { get; set; } = string.Empty;
    }
}
