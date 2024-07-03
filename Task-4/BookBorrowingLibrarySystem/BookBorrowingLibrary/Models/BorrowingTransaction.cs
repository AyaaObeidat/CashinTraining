namespace BookBorrowingLibrary.Models
{
    public class BorrowingTransaction
    {
        public Guid Id { get; set; }
        public Guid UserId { get; private set; }
        public Guid BookId { get; private set; }
        public DateTime BorrowedDate { get; private set; }
        public DateTime ReturnedDate { get; private set; }

        private BorrowingTransaction() { }
        private BorrowingTransaction( Guid userId, Guid bookId)
        {
            
            UserId = userId;
            BookId = bookId;
            BorrowedDate = DateTime.Now;
            ReturnedDate = BorrowedDate.AddDays(14);
        }

        public static BorrowingTransaction Create(Guid userId, Guid bookId)
        {
            if(userId == Guid.Empty || bookId == Guid.Empty)  throw new ArgumentNullException();
            return new BorrowingTransaction(userId, bookId);
        }
    }
}
