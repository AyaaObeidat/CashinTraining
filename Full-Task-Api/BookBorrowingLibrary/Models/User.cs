
using BookBorrowingLibraryEnums;

namespace BookBorrowingLibrary.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public Guid BookId { get;private set; }    
        public string FullName { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public long PhoneNumber { get; private set; }
        public string Password { get; private set; }  =null!;
        public bool IsAdmin { get; private set; }
        public RequestStatus Status { get; private set; }

        private User() { }
        private User( string fullName, string email, long phoneNumber, string password)
        {
            
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;
            IsAdmin = true;
            Status = RequestStatus.Pending;
        }

        public static User Create(string fullName, string email, long phoneNumber, string password)
        {
            if(string.IsNullOrEmpty(fullName)) throw new ArgumentNullException("Full name cannot be null or empty.");
            if(string.IsNullOrEmpty(email)) throw new ArgumentNullException("Email cannot be null or empty.");
            if (string.IsNullOrEmpty(password)) throw new ArgumentNullException("Password cannot be null or empty.");

            return new User(fullName, email, phoneNumber, password);
         }

        public void SetFullName(string fullName)
        {
            this.FullName = fullName;
        }
        public void SetPassword(string password)
        {
            this.Password = password;
        }
        public void SetPhoneNumber(long phoneNumber)
        {
            this.PhoneNumber = phoneNumber;
        }

        public void SetAcceptedStatus()
        {
            this.Status = RequestStatus.Accepted;
        }

        public void SetRejectedStatus()
        {
            this.Status = RequestStatus.Rejected;
        }   

        public void SetBookId(Guid bookId)
        {
            //if(bookId == Guid.Empty) throw new ArgumentNullException();
            this.BookId = bookId;
        }

        public void SetIsCustomer()
        {
            IsAdmin = false;
        }
    }
}
