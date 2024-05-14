using Mahali.Models;
using System.ComponentModel.DataAnnotations;

namespace Mahali.Dtos.ProductDtos
{
    public class ProductCreateParameters
    {

        [Required(ErrorMessage = "Product name is required.")]
        [RegularExpression(@"^[a-zA-Z]{3,10}$", ErrorMessage = "Name must be between 3 and 10 alphabetical characters.")]
        public string Name { get;  set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 50 characters.")]
        public string Description { get;  set; } 

        [Required(ErrorMessage = "Quantity of Product is required.")]
        public int Quantity { get;  set; }

        [Required(ErrorMessage = "Price of Product is required.")]
        public decimal Price { get;  set; } = 0!;

        [Required(ErrorMessage = "ImageUri of Product is required.")]
        public string ImageUri { get;  set; } = null!;

        [Required]
        public Guid shopId { get; set; }

 
    }
}
