using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBorrowingLibraryDtos.UserDtos
{
    public class UserUpdateParameters
    {
        public string CurrentName { get; set; }
        public string NewName { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }

    }
}
