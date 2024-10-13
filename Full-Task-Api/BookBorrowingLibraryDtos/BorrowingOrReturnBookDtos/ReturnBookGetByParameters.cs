using BookBorrowingLibraryEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBorrowingLibraryDtos.BorrowingOrReturnBookDtos
{
    public class ReturnBookGetByParameters
    {
        public Guid Id { get; set; }
        public BookStatus BookStatus { get; set; }
    }
}
