using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBorrowingLibraryDtos.BookDtos
{
    public class BookUpdateParameter
    {
        public Guid Id { get; set; }
        public string NewTitle { get; set; }
        public string NewAuthor { get; set; }
        public string NewPublisher { get; set; }
        public string NewPublicationYear { get; set; }
        public int NewNumberOfAvailableCopies { get; set; }
        public int NewTotalNumberOfCopies { get; set; }

    }
}
