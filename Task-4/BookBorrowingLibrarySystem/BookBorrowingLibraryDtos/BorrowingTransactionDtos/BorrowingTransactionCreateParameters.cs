using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBorrowingLibraryDtos.BorrowingTransactionDtos
{
    public class BorrowingTransactionCreateParameters
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
    }
}
