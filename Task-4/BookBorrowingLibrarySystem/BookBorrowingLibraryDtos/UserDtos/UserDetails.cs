
using BookBorrowingLibraryDtos.BookDtos;
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
        public string TripleName { get;  set; } 
        public UserGender Gender { get;  set; }
        public string Email { get;  set; } 
        public List<BookDetails>? Books { get;  set; }
    }
}
