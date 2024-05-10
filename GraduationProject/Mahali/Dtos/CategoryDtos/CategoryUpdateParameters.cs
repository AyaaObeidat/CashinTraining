using System.ComponentModel.DataAnnotations;

namespace Mahali.Dtos.CategoryDtos
{
    public class CategoryUpdateParameters
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
