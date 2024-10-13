using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBorrowingLibraryDtos.AdminDtos
{
    public class AdminDetails
    {
        public Guid Id { get; set; }
        public string FullName { get;  set; } 
        public string Email { get;  set; } 
        public long PhoneNumber { get;  set; }  
    }
}
