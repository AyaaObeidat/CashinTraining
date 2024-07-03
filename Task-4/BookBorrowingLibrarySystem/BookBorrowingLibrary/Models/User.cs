using BookBorrowingLibraryEnums;
using System.Diagnostics.Metrics;

namespace BookBorrowingLibrary.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string TripleName { get; private set; } = null!;
        public UserGender Gender { get; private set; } 
        public string Email { get; private set; } = null!;
        public string Password { get; private set; } = null!;
        public List<BorrowingTransaction>  Books { get; private set; }
        private User()
        {

        }

        private User (string tripleName, UserGender gender, string email, string password)
        {
            TripleName = tripleName;
            Gender = gender;
            Email = email;
            Password = password;
        }

        public static User Create (string tripleName, UserGender gender, string email, string password)
        {
            int spaceCount = 0 ;
            spaceCount = tripleName.Count(c => c == ' ');
            if (spaceCount != 2 || string.IsNullOrEmpty(tripleName)) throw new ArgumentNullException();
            if(string.IsNullOrEmpty(email)) throw new ArgumentNullException();
            if(string.IsNullOrEmpty(password)) throw new ArgumentNullException();

            return new User(tripleName, gender, email, password);
        }

        public void SetTripleName(string tripleName)
        {
            int spaceCount = 0;
            spaceCount = tripleName.Count(c => c == ' ');
            if (spaceCount != 2 || string.IsNullOrEmpty(tripleName)) throw new ArgumentNullException();
            TripleName = tripleName;
        }

        public void SetGender(UserGender gender)
        {
            Gender = gender;
        }

        public void SetEmail(string email)
        {
            Email = email;
        }

        public void SetPassword(string password)
        {
            if (string.IsNullOrEmpty(password)) throw new ArgumentNullException();
            Password = password;
        }

        public void SetBooks (List<BorrowingTransaction> books)
        {
            Books = books;
        }
    }
}
