using MessagingSystem.Dtos.UserDtos;
using MessagingSystem.Dtos.UserProfileDtos;
using MessagingSystem.Models;
using MessagingSystem.Repositories.Implementations;
using MessagingSystem.Repositories.Interfaces;

namespace MessagingSystem.Services
{
    public class UserProfileService
    {
        private readonly IUserProfileInterface _userProfileInterface;
        private readonly IUserInterface _userInterface;

        public UserProfileService(IUserProfileInterface userProfileInterface , IUserInterface userInterface)
        {
            _userProfileInterface = userProfileInterface;
            _userInterface = userInterface;
        }
        public async Task<List<UserProfileDetails>> GetAllAsync()
        {
            var profiles = await _userProfileInterface.GetAllAsync();
            return profiles.Select(p => new UserProfileDetails
            {
                Id = p.Id,
                UserId = p.UserId,
                InboxId = p.InboxId,
                FullName = p.FullName,
                Email = p.Email,
                Bio = p.Bio,

            }).ToList();
        }

        public async Task<UserProfileDetails> GetByIdAsync(Guid id)
        {
            var profile  = await _userProfileInterface.GetByIdAsync(id);
            return new UserProfileDetails
            {
                Id = profile.Id,
                UserId = profile.UserId,
                InboxId = profile.InboxId,
                FullName = profile.FullName,
                Email = profile.Email,
                Bio = profile.Bio
            };
        }

        public async Task AddAsync(UserProfileCreateParameters parameters)
        {
            var user = await _userInterface.GetByIdAsync(parameters.UserId);
            var profile = UserProfile.Create(parameters.UserId, user.FirstName + " " + user.LastName, user.Email, parameters.Bio);
            await _userProfileInterface.AddAsync(profile);
            user.SetUserProfileId(profile.Id);
            await _userInterface.UpdateAsync(user);
        }

        public async Task DeleteAsync(Guid id)
        {
            var profile = await _userProfileInterface.GetByIdAsync(id);
            await _userProfileInterface.DeleteAsync(profile);
        }

        public async Task UpdateFullNameAsync(UserProfileUpdateParameters parameters)
        {
            var profile = await _userProfileInterface.GetByIdAsync(parameters.Id);
            profile.SetName(parameters.FullName);
            await _userProfileInterface.UpdateAsync(profile);
        }
        public async Task UpdateEmailAsync(UserProfileUpdateParameters parameters)
        {
            var profile = await _userProfileInterface.GetByIdAsync(parameters.Id);
            profile.SetEmail(parameters.Email);
            await _userProfileInterface.UpdateAsync(profile);
        }
        public async Task UpdateBioAsync(UserProfileUpdateParameters parameters)
        {
            var profile = await _userProfileInterface.GetByIdAsync(parameters.Id);
            profile.SetBio(parameters.Bio);
            await _userProfileInterface.UpdateAsync(profile);
        }
    }
}
