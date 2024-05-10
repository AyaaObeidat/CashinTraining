using System.ComponentModel.DataAnnotations;

namespace Mahali.Dtos.AdminDtos
{
    public class AdminCreateParameters
    {
        [Required(ErrorMessage = "Shop name is required.")]
        [RegularExpression(@"^[a-zA-Z]{3,10}$", ErrorMessage = "FirstName must be between 3 and 10 alphabetical characters.")]
        public string UserName { get;  set; } 


        [Required(ErrorMessage = "Password is required.")]
        [RegularExpression(@"^(?=.*\d)(?=.*[A-Z])(?=.*[!@#$%^&*()-+=])[a-zA-Z\d!@#$%^&*()-+=]{8,16}$", ErrorMessage = "Password must be between 8 and 16 characters long, contain at least 3 numbers, 1 uppercase letter, and 1 special symbol.")]
        public string Password { get;  set; } 

        [Required(ErrorMessage = "Email is required.")]
        [StringLength(25, MinimumLength = 14, ErrorMessage = "Email must be between 14 and 25 characters long.")]
        public string Email { get;  set; } 
    }
}
