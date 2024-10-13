using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBorrowingLibraryDtos.CustomerDtos
{
    public class RegisterParameters
    {
        public string FullName { get;  set; } 
        public string Email { get;  set; } 
        public long PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
