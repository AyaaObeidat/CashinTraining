using BookBorrowingLibraryEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBorrowingLibraryDtos.BookDtos
{
    public class BookUpdateParameters
    {
        public string CurrentName { get;  set; }
        public string NewName { get; set; }
        public int NumberOfCopies { get;  set; }    
        public BookStatus Status { get; set; }
    }
}
