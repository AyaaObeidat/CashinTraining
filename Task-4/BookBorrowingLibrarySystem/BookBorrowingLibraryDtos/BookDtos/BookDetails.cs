
using BookBorrowingLibraryDtos.BorrowingTransactionDtos;
using BookBorrowingLibraryDtos.UserDtos;
using BookBorrowingLibraryEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBorrowingLibraryDtos.BookDtos
{
    public class BookDetails
    {
        public Guid Id { get; set; }
        public string Name { get;  set; } 
        public int NumberOfCopies { get; set; }     
        public BookClassification Classification { get; set; }
        public BookStatus Status { get; set; }
        public List<BorrowingTransactionDetails> Users { get;  set; }

    }
}
