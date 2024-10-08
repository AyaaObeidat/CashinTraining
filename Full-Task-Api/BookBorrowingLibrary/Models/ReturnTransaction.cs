using BookBorrowingLibraryEnums;

namespace BookBorrowingLibrary.Models
{
    public class ReturnTransaction
    {
        public Guid Id { get; set; }
        public Guid UserId { get; private set; }
        public Guid BookId { get; private set; }
        public DateTime ReturnedDate { get; private set; }
        public BookStatus BookStatus { get; private set; }
        private ReturnTransaction() { }
        private ReturnTransaction(Guid userId, Guid bookId)
        {

            UserId = userId;
            BookId = bookId;
            ReturnedDate = DateTime.Now;

        }
        public static ReturnTransaction  Create(Guid userId, Guid bookId)
        {
            if (userId == Guid.Empty) throw new ArgumentNullException("userId cannot be null");
            if (bookId == Guid.Empty) throw new ArgumentNullException("bookId cannot be null");
            return new ReturnTransaction(userId, bookId);
        }

        public void SetDamagedBookStatus()
        {
            this.BookStatus = BookStatus.Damaged;
        }   
        public void SetNonCorruptBookStatus()
        {
            this.BookStatus = BookStatus.NonCorrupt;
        }
    }
}
