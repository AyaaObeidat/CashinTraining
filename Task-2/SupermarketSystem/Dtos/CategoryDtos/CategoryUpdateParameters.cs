using SupermarketSystem.Models;

namespace SupermarketSystem.Dtos.CategoryDtos
{
    public class CategoryUpdateParameters
    {
        public Guid Id { get; set; }
        public string Name { get;  set; }
    }
}
