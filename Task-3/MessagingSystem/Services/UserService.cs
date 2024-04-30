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
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Password = u.Password,  
                UserProfileId = u.UserProfileId
            }).ToList();    
        }

        public async Task<UserDetails> GetByIdAsync(Guid id)
        {
            var user = await _userInterface.GetByIdAsync(id);
            if (user == null) return null;
            return new UserDetails
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                UserProfileId = user.UserProfileId
            };
        }

        public async Task AddAsync(UserCreateParameters parameters)
        {
            var user = User.Create(parameters.FirstName, parameters.LastName, parameters.Email, parameters.Password);
            await _userInterface.AddAsync(user);
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _userInterface.GetByIdAsync(id);
            if (user == null) return;
            await _userInterface.DeleteAsync(user);
        }
    }
}
