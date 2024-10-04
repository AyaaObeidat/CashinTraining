using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSystemDtos.UserDtos
{
    public class UserLoginParameter
    {
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get;  set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get;  set; }
    }
}
