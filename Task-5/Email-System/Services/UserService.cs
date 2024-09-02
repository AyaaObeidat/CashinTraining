using Email_System.Models;
using Email_System.Repositories.Interfaces;
using EmailSystemDtos.UserDtos;
using Microsoft.AspNetCore.Server.IIS;
namespace Email_System.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IInboxRepository _inboxRepository;
        private readonly IOutboxRepository _outboxRepository;
        private readonly ITrashRepository _trashRepository;

        public UserService(IUserRepository userRepository, IInboxRepository inboxRepository, IOutboxRepository outboxRepository, ITrashRepository trashRepository)
        {
            _userRepository = userRepository;
            _inboxRepository = inboxRepository;
            _outboxRepository = outboxRepository;
            _trashRepository = trashRepository;
        }

        public async Task RegisterAsync(UserCreateParameter parameters)
        {
            var users = await _userRepository.GetAllAsync();
            foreach (var u in users)
            {
                if (u.Email != parameters.Email && u.FullName != parameters.FullName) continue;
                else throw new ArgumentException("User with the same email or full name already exists.");
            }
            var user =  User.Create(parameters.FullName , parameters.Email , parameters.Password , parameters.Address);
            await _userRepository.AddAsync(user);

            var inbox = Inbox.Create(user.Id);
            await _inboxRepository.AddAsync(inbox); 

            var outbox = Outbox.Create(user.Id);
            await _outboxRepository.AddAsync(outbox);

            var trash = Trash.Create(user.Id);
            await _trashRepository.AddAsync(trash);

            user.SetInboxId(inbox.Id);
            await _userRepository.UpdateAsync(user);
            user.SetOutboxId(outbox.Id);
            await _userRepository.UpdateAsync(user);
            user.SetTrashId(trash.Id);
            await _userRepository.UpdateAsync(user);


        }
        
        public async Task<UserDetails?> LoginAsync(UserLoginParameter parameters)
        {
            var users = await _userRepository.GetAllAsync();
            foreach (var u in users)
            {
                if(u.Email == parameters.Email && u.Password == parameters.Password)
                {
                    return new UserDetails
                    {
                        Id = u.Id,
                        FullName = u.FullName,
                        Email = u.Email,
                        Password = u.Password,
                        Address = u.Address,
                        ImageUrl = u.ImageUrl,
                        InboxId = u.InboxId,
                        OutboxId = u.OutboxId,
                        TrashId = u.TrashId,
                    };
                }
            }
            throw new UnauthorizedAccessException("Invalid email or password.");
        }

        public async Task<List<UserDetails>?> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            if(users.Count==0) return null;
            return users.Select(u => new UserDetails
            {

                Id = u.Id,
                FullName = u.FullName,
                Email = u.Email,
                Password = u.Password,
                Address = u.Address,
                ImageUrl = u.ImageUrl,
                InboxId = u.InboxId,
                OutboxId = u.OutboxId,
                TrashId = u.TrashId,

            }).ToList();
        }

        public async Task<UserDetails?> GetByIdAsync(UserGetByParameter parameters)
        {
            var user = await _userRepository.GetByIdAsync(parameters.Id);
            if (user == null) throw new ArgumentException("User was not found.");
            return new UserDetails
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Password = user.Password,
                Address = user.Address,
                ImageUrl = user.ImageUrl,
                InboxId = user.InboxId,
                OutboxId = user.OutboxId,
                TrashId = user.TrashId,
                //messages
            };
        }

        public async Task ModifyFullNameAsync (UserUpdateParameter parameter)
        {
            var user = await _userRepository.GetByIdAsync (parameter.Id);
            if (user == null) throw new ArgumentException("User was not found.");
            var users = await _userRepository.GetAllAsync();
            foreach (var u in users)
            {
                if ( u.FullName != parameter.NewFullName) continue;
                else throw new ArgumentException("User with the same full name already exists.");
            }
            user.SetFullName(parameter.NewFullName);
            await _userRepository.UpdateAsync(user);
        }

        public async Task ModifyPasswordAsync(UserUpdateParameter parameter)
        {
            var user = await _userRepository.GetByIdAsync(parameter.Id);
            if (user == null) throw new ArgumentException("User was not found.");
            if(user.Password == parameter.CurrentPassword)
            {
                if (user.Password == parameter.NewPassword) throw new ArgumentException("The new password cannot be the same as the current password.");
                else
                {
                    user.SetPassword(parameter.NewPassword);
                    await _userRepository.UpdateAsync(user);
                }
            }
            else throw new ArgumentException("The current password is incorrect.");
        }

        public async Task ModifyProfileImageAsync(UserUpdateParameter parameter)
        {
            var user = await _userRepository.GetByIdAsync(parameter.Id);
            if (user == null) throw new ArgumentException("User was not found.");
            if (user.ImageUrl == parameter.ImageUrl) return;
            else
            {
                user.SetImageUrl(parameter.ImageUrl);
                await _userRepository.UpdateAsync(user);
            }

        }
    }
}
