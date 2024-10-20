namespace BookBorrowingLibrary.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public Guid UserId { get; private set; }
        public string Title { get; private set; } = null!;
        public string Description { get; private set; } = null!;
        public string Author { get; private set; } = null!;
        public string Publisher { get; private set; } = null!;
        public string PublicationYear { get; private set; } = null!;
        public int NumberOfAvailableCopies { get; private set; }
        public int TotalNumberOfCopies { get; private set; }

        private Book() { }
        private Book(string title,string description , string author, string publisher, string publicationYear, int numberOfAvailableCopies, int totalNumberOfCopies )
        {
            
            Title = title;
            Description = description;
            Author = author;
            Publisher = publisher;
            PublicationYear = publicationYear;
            NumberOfAvailableCopies = numberOfAvailableCopies;
            TotalNumberOfCopies = totalNumberOfCopies;
        }

        public static Book Create(string title,string description ,  string author, string publisher, string publicationYear, int numberOfAvailableCopies, int totalNumberOfCopies)
        {
            if (string.IsNullOrEmpty(title)) throw new ArgumentNullException("title cannot be null or empty.");
            if (string.IsNullOrEmpty(description)) throw new ArgumentNullException("description cannot be null or empty.");
            if (string.IsNullOrEmpty(author)) throw new ArgumentNullException("Author cannot be null or empty.");
            if (string.IsNullOrEmpty(publisher)) throw new ArgumentNullException("Publisher cannot be null or empty.");
            if (string.IsNullOrEmpty(publicationYear)) throw new ArgumentNullException("Year cannot be null or empty.");
            if (numberOfAvailableCopies < 0) throw new ArgumentOutOfRangeException("number of available copies cannot be negative");
            if (totalNumberOfCopies <= 0) throw new ArgumentOutOfRangeException("number of total copies cannot be zero or negative");

            return new Book(title,description, author, publisher, publicationYear, numberOfAvailableCopies, totalNumberOfCopies);

        }

        public void SetTitle(string title)
        {
            this.Title = title; 
        }
        public void SetAuthor(string author)
        {
            this.Author = author;
        }
        public void SetPublisher(string publisher)
        {
            this.Publisher = publisher;
        }
        public void SetPublisherYear(string publisherYear)
        {
            this.PublicationYear = publisherYear;
        }
        public void SetNumberOfAvailableCopies(int numberOfAvailableCopies)
        {
            this.NumberOfAvailableCopies = numberOfAvailableCopies;
        }
        public void SetTotalNumberOfCopies(int totalNumberOfCopies)
        {
            this.TotalNumberOfCopies = totalNumberOfCopies  ;
        }
        public void SetUserId(Guid userId)
        {
           // if(userId == Guid.Empty) throw new ArgumentNullException();
            this.UserId = userId; 
        }

    }
}
