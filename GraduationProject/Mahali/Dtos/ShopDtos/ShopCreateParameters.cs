using System.ComponentModel.DataAnnotations;

namespace Mahali.Dtos.ShopDtos
{
    public class ShopCreateParameters
    {

        [Required(ErrorMessage = "Shop name is required.")]
        [RegularExpression(@"^[a-zA-Z]{3,10}$", ErrorMessage = "FirstName must be between 3 and 10 alphabetical characters.")]
        public string Name { get; private set; } = null!;

        [Required(ErrorMessage = "Shop description is required.")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 50 characters.")]
        public string Description { get; private set; } = null!;

        [Required(ErrorMessage = "Password is required.")]
        [RegularExpression(@"^(?=.*\d)(?=.*[A-Z])(?=.*[!@#$%^&*()-+=])[a-zA-Z\d!@#$%^&*()-+=]{8,16}$", ErrorMessage = "Password must be between 8 and 16 characters long, contain at least 3 numbers, 1 uppercase letter, and 1 special symbol.")]
        public string Password { get; private set; } = null!;

        [Required(ErrorMessage = "Email is required.")]
        [StringLength(25, MinimumLength = 14, ErrorMessage = "Email must be between 14 and 25 characters long.")]
        [RegularExpression(@"^[^\s@]+@[^\s@]+\.[^\s@]+$", ErrorMessage = "Invalid email format.")]
        public string Email { get; private set; } = null!;

        [Required(ErrorMessage = "Phone number is required.")]
        [Range(10, 10, ErrorMessage = "PNumber must be equal to 10.")]
        public long PhoneNumber { get; private set; }

        [Required]
        public Guid LocationId { get; private set; }
    }
}
