
using BookBorrowingLibraryDtos.BookDtos;
using BookBorrowingLibraryDtos.BorrowingTransactionDtos;
using BookBorrowingLibraryEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBorrowingLibraryDtos.UserDtos
{
    public class UserDetails
    {
        public Guid Id { get; set; }
        public string TripleName { get;  set; } 
        public UserGender Gender { get;  set; }
        public string Email { get;  set; } 
        public decimal TotalOfBorrowingPrice { get; set; }
        public List<BorrowingTransactionDetails>? Books { get;  set; }
    }
}
