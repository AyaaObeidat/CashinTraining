using Mahali.Models;

namespace Mahali.Dtos.CategoryDtos
{
    public class CategoryListItems
    {
        public string Name { get; set; } 
        public List<Product> Products { get; set; } 
    }
}
