using BookBorrowingLibraryEnums;

namespace BookBorrowingLibrary.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Name { get; private set; } = null!;
        public int NumberOfCopies { get;private set; } = 0!;
        public BookClassification Classification { get; private set; } 
        public BookStatus Status { get; private set; }

        public List<BorrowingTransaction> Users { get; private set; }
        private Book() { }
        private Book( string name, int numberOfCopies, BookClassification classification)
        {
            
            Name = name;
            NumberOfCopies = numberOfCopies;
            Classification = classification;
            Status = BookStatus.NotBorrowed;
        }

        public static Book Create(string name, int numberOfCopies, BookClassification classification)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException();
            if (numberOfCopies < 0) throw new ArgumentOutOfRangeException();
            return new Book(name, numberOfCopies,classification);
        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException();
            Name = name;
        }
        public void SetNumberOfCopies(int numberOfCopies)
        {
            if (numberOfCopies < 0) throw new ArgumentOutOfRangeException();
            NumberOfCopies = numberOfCopies;
        }

        public void SetClassification(BookClassification classification)
        {
            Classification = classification;
        }
        public void SetStatus(BookStatus status)
        {
            Status = status;
        }

        public void SetUsers(List<BorrowingTransaction> users)
        {
            Users = users;
        }

    }
}
