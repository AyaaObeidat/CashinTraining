using BookBorrowingLibraryDtos.BookDtos;
using BookBorrowingLibraryEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBorrowingLibraryDtos.CustomerDtos
{
    public class CustomerDetails
    {
        public Guid Id { get; set; }
        public BookDetails Book { get;  set; }
        public string FullName { get;  set; }
        public string Email { get;  set; }
        public long PhoneNumber { get; set; }
        public string Password { get;  set; } 
        public bool IsAdmin { get; set; }
        public RequestStatus Status { get; set; }
    }
}
