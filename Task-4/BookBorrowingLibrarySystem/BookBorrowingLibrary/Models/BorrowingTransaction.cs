using BookBorrowingLibraryEnums;

namespace BookBorrowingLibrary.Models
{
    public class BorrowingTransaction
    {
        public Guid Id { get; set; }
        public Guid UserId { get; private set; }
        public Guid BookId { get; private set; }
        public DateTime BorrowedDate { get; private set; }
        public DateTime RequiredReturnDate { get; private set; }
        public DateTime ActualReturnDate { get; private set; }
        public decimal ArrangedFine { get; private set; }

        public BookReturnStatus ReturnStatus { get; private set; }              
        private BorrowingTransaction() { }
        private BorrowingTransaction( Guid userId, Guid bookId)
        {
            
            UserId = userId;
            BookId = bookId;
            BorrowedDate = DateTime.Now;
            RequiredReturnDate = BorrowedDate.AddDays(14);
            ReturnStatus = BookReturnStatus.NotReturned;
        }

        public static BorrowingTransaction Create(Guid userId, Guid bookId)
        {
            if(userId == Guid.Empty || bookId == Guid.Empty)  throw new ArgumentNullException();
            return new BorrowingTransaction(userId, bookId);
        }

        public void SetActualReturnDate()
        {
            ActualReturnDate = DateTime.Now;
        }

        public void SetArrangedFine (decimal arrangedFine)
        {
            ArrangedFine = arrangedFine;
        }

        public void SetBookReturnStatus ()
        {
            ReturnStatus = BookReturnStatus.Returned;
        }
    }
}
