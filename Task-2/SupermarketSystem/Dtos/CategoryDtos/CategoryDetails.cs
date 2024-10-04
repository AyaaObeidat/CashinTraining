using SupermarketSystem.Models;

namespace SupermarketSystem.Dtos.CategoryDtos
{
    public class CategoryDetails
    {
        public Guid Id { get; set; }
        public string Name { get;  set; } = null!;

        public List<Product> ProductsList { get;  set; }

    }
}
