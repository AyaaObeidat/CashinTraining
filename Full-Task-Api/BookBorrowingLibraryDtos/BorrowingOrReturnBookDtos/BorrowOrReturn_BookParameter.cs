using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBorrowingLibraryDtos.BorrowingBook
{
    public class BorrowOrReturn_BookParameter
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
    }
}
