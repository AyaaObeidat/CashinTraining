using BookBorrowingLibraryDtos.CustomerDtos;
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
        public CustomerDetails Customer { get;  set; }
        public string Title { get;  set; } 
        public string Author { get; set; } 
        public string Publisher { get; set; } 
        public string PublicationYear { get; set; } 
        public int NumberOfAvailableCopies { get; set; }
        public int TotalNumberOfCopies { get; set; }
    }
}
