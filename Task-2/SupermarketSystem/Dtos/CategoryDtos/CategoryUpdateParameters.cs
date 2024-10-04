using SupermarketSystem.Models;

namespace SupermarketSystem.Dtos.CategoryDtos
{
    public class CategoryUpdateParameters
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
    }
}
