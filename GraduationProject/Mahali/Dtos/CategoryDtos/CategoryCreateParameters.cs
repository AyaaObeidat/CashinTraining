using System.ComponentModel.DataAnnotations;

namespace Mahali.Dtos.CategoryDtos
{
    public class CategoryCreateParameters
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get;  set; } 

    }
}
