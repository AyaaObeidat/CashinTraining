using BookBorrowingLibraryEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBorrowingLibraryDtos.BookDtos
{
    public class BookCreateParameters
    {
        public string Name { get;  set; } 
        public int NumberOfCopies { get;  set; } 
        public BookClassification Classification { get;  set; }
    }
}
