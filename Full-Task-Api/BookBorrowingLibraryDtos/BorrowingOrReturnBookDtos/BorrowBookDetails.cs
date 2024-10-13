using BookBorrowingLibraryDtos.BookDtos;
using BookBorrowingLibraryDtos.CustomerDtos;
using BookBorrowingLibraryEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBorrowingLibraryDtos.BorrowingOrReturnBookDtos
{
    public class BorrowBookDetails
    {
        public Guid Id { get; set; }
        public CustomerDetails Customer { get;  set; }
        public BookDetails Book { get;  set; }
        public DateTime CreatedDate { get;  set; }
        public BookStatus BookStatus { get;  set; }
        public RequestStatus RequestStatus { get;  set; }
        public DeliveryStatus DeliveryStatus { get;  set; }
    }
}
