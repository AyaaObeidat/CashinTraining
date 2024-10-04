using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSystemDtos.UserDtos
{
    public class UserUpdateParameter
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Full Name is required.")]
        [StringLength(100, ErrorMessage = "Full Name cannot be longer than 100 characters.")]
        public string NewFullName { get; set; }

        [Required(ErrorMessage = "Current-Password is required.")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
        public string NewPassword { get; set; }

        public string ImageUrl { get; set; }
    }
}
