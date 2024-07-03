using BookBorrowingLibrary.Models;
using BookBorrowingLibrary.Repositories.Interfaces;
using BookBorrowingLibraryDtos.BookDtos;
using BookBorrowingLibraryDtos.UserDtos;
namespace BookBorrowingLibrary.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task RegisterAsync (UserRegister user)
        {
            var users = await _userRepository.GetAllAsync();
            foreach(var u in users)
            {
                if (u.TripleName != user.TripleName && u.Email != user.Email) continue;
                else throw new ArgumentException();
            }
            var newUser =  User.Create(user.TripleName, user.Gender, user.Email, user.Password);
            await _userRepository.AddAsync(newUser);
        }

        public async Task<UserDetails?> LoginAsync(UserLogin user)
        {
            var users = await _userRepository.GetAllAsync();
            foreach(var u in users.ToList())
            {
                if(u.Email == user.Email && u.Password == user.Password)
                {
                    var currentUser = await _userRepository.GetByIdAsync(u.Id);
                    currentUser.SetBooks(currentUser.Books);
                    await _userRepository.UpdateAsync(currentUser);

                    var books = currentUser.Books.Select(x => new BookDetails
                    {
                        Name = x.Name,
                        NumberOfCopies = x.NumberOfCopies,
                        Classification = x.Classification,
                        Status = x.Status,
                    });

                    return new UserDetails
                    {
                        TripleName = u.TripleName,
                        Gender = u.Gender,
                        Email = u.Email,
                        Books = books.ToList()
                    };
                }

            }
            return null;
        }

        public async Task<List<UserDetails>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.ToList().Select(x => new UserDetails
            {
                TripleName = x.TripleName,
                Gender = x.Gender,
                Email = x.Email,
                Books = x.Books.Select(u => new BookDetails
                {
                    Name = u.Name,
                    NumberOfCopies = u.NumberOfCopies,
                    Classification = u.Classification,
                    Status = u.Status,

                }).ToList()
            }).ToList();
        }

        public async Task<UserDetails?> GetByIdAsync(UserGetByParameter parameter)
        {
            var user = await _userRepository.GetByIdAsync(parameter.Id);
            if (user == null) return null;
            var books = user.Books.Select(x => new BookDetails
            {
                Name = x.Name,
                NumberOfCopies = x.NumberOfCopies,
                Classification = x.Classification,
                Status = x.Status,
            });

            return new UserDetails
            {
                TripleName = user.TripleName,
                Gender = user.Gender,
                Email = user.Email,
                Books = books.ToList()
            };
        }

        public async Task ModifyName(UserUpdateParameters user)
        {
            var users = await _userRepository.GetAllAsync();
            foreach(var u  in users)
            {
                if (user.NewName != u.TripleName)
                {

                    if (user.CurrentName == u.TripleName)
                    {
                        u.SetTripleName(user.NewName);
                        await _userRepository.UpdateAsync(u);

                    }
                }
                else return;

            }

        }

        public async Task ModifyPassword(UserUpdateParameters user)
        {
            var users = await _userRepository.GetAllAsync();
            foreach (var u in users)
            {
                    if (user.CurrentPassword == u.Password)
                    {
                        u.SetPassword(user.NewPassword);
                        await _userRepository.UpdateAsync(u);

                    }
            }

        }
    }
}
