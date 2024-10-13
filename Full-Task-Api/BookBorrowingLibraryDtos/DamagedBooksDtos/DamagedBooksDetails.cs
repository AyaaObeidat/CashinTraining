using BookBorrowingLibraryDtos.BookDtos;
using BookBorrowingLibraryEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBorrowingLibraryDtos.DamagedBooksDtos
{
    public class DamagedBooksDetails
    {
        public Guid Id { get; set; }
        public BookDetails Book { get;  set; }
        public int NumberOfDamagedCopies { get;  set; } 
        public DamageProceedings DamageProceedings { get; set; }
    }
}
