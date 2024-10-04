using MessagingSystem.Dtos.UserDtos;
using MessagingSystem.Models;
using MessagingSystem.Repositories.Interfaces;

namespace MessagingSystem.Services
{
    public class UserService
    {
        private readonly IUserInterface _userInterface;
        public UserService(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        public async Task<List<UserDetails>> GetAllAsync()
        {
            var users = await _userInterface.GetAllAsync();
            return users.Select(u => new UserDetails
            {
                Id = u.Id,  
                FullName = u.FullName,
                Email = u.Email,
                Messages = u.Messages,
            }).ToList();
        }
        public async Task<UserDetails> GetByIdAsync(Guid id)
        {
            var user = await _userInterface.GetByIdAsync(id);
            return new UserDetails
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Messages = user.Messages,
            };
        }

        public async Task AddAsync(UserCreateParameters parameters)
        {
            var user = User.Create(parameters.FullName , parameters.Email);
            await _userInterface.AddAsync(user);
        }

        public async Task DeleteAsync(Guid id)
        {
            var user =await _userInterface.GetByIdAsync(id);
            await _userInterface.DeleteAsync(user);
        }
    }
}
