using System.ComponentModel.DataAnnotations;

namespace Mahali.Dtos.CategoryDtos
{
    public class CategoryUpdateParameters
    {
        
        public Guid CategoryId { get; set; }
        public string UpdatedName { get; set; }
    }
}
