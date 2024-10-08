using BookBorrowingLibraryEnums;

namespace BookBorrowingLibrary.Models
{
    public class DamagedBooks
    {
        public Guid Id { get; set; }
        public Guid BookId { get;private set; }
        public int NumberOfDamagedCopies { get; private set; } = 0;
        public DamageProceedings DamageProceedings { get;private set; }

        private DamagedBooks() { }
        private DamagedBooks(Guid bookId)
        {
            this.BookId = bookId;
            DamageProceedings = DamageProceedings.None; 
        }
        public static DamagedBooks Create(Guid bookId)
        {
            if (bookId == Guid.Empty) throw new ArgumentNullException("Book Id cannot be null");
            return new DamagedBooks(bookId);
        }

        public void UpdateNumberOfDamagedCopies()
        {
            this.NumberOfDamagedCopies++;
        }

        public void SetReformDamageProceedings()
        {
            this.DamageProceedings = DamageProceedings.Reform;
        }
        public void SetGetRidDamageProceedings()
        {
            this.DamageProceedings = DamageProceedings.GetRid ;
        }
    }
}
