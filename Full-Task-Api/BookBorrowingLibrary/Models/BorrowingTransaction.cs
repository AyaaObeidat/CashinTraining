using BookBorrowingLibraryEnums;

namespace BookBorrowingLibrary.Models
{
    public class BorrowingTransaction
    {
        public Guid Id { get; set; }
        public Guid UserId { get;private set; }
        public Guid BookId { get;private set; }
        public DateTime CreatedDate { get;private set; }
        public BookStatus BookStatus { get;private set; }
        public RequestStatus RequestStatus { get;private set; }
        public DeliveryStatus DeliveryStatus { get; private set; }

        private BorrowingTransaction() { }
        private BorrowingTransaction( Guid userId, Guid bookId)
        {
            
            UserId = userId;
            BookId = bookId;
            CreatedDate = DateTime.Now;
            BookStatus = BookStatus.NonCorrupt;
            RequestStatus = RequestStatus.Pending;
            DeliveryStatus = DeliveryStatus.NotReceived;
        }
        public static BorrowingTransaction Create( Guid userId, Guid bookId )
        {
            if(userId == Guid.Empty) throw new ArgumentNullException("userId cannot be null");
            if (bookId == Guid.Empty) throw new ArgumentNullException("bookId cannot be null");
            return new BorrowingTransaction (userId, bookId);
        }

        public void SetDeliveryStatus()
        {
            this.DeliveryStatus = DeliveryStatus.Received;
        }
        public void SetAcceptedRequestStatus()
        {
            this.RequestStatus = RequestStatus.Accepted;
        }

        public void SetRejectedRequestStatus()
        {
            this.RequestStatus = RequestStatus.Rejected ;

        }
    }
}
