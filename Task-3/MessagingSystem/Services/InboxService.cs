using MessagingSystem.Dtos.InboxDtos;
using MessagingSystem.Dtos.UserDtos;
using MessagingSystem.Models;
using MessagingSystem.Repositories.Implementations;
using MessagingSystem.Repositories.Interfaces;

namespace MessagingSystem.Services
{
    public class InboxService
    {
        private readonly IInboxInterface _inbox;
        private readonly IUserProfileInterface _userProfile;
        public InboxService (IInboxInterface inbox, IUserProfileInterface userProfile)
        {
            _inbox = inbox;
            _userProfile = userProfile;
        }

        public async Task<List<InboxDetails>> GetAllAsync()
        {
            var inboxes = await _inbox.GetAllAsync();
            return inboxes.Select(i => new InboxDetails
            {
               Id = i.Id,
               UserProfileId = i.UserProfileId,
               Messages = i.Messages,
            }).ToList();
        }

        public async Task<InboxDetails> GetByIdAsync(Guid id)
        {
            var inbox = await _inbox.GetByIdAsync(id);
            if (inbox == null) return null;
            return new InboxDetails
            {
                Id = inbox.Id,
                UserProfileId = inbox.UserProfileId,
                Messages = inbox.Messages,
            };
        }

        public async Task AddAsync(InboxCreateParameters parameters)
        {
            var profile = await _userProfile.GetByIdAsync(parameters.UserProfileId);
            if (profile == null) return;
            var inbox = Inbox.Create(parameters.UserProfileId);
            await _inbox.AddAsync(inbox);
            profile.SetInboxId(inbox.Id);
            await _userProfile.UpdateAsync(profile);
        }

        public async Task DeleteAsync(Guid id)
        {
            var inbox = await _inbox.GetByIdAsync(id);
            if (inbox == null) return;
            await _inbox.DeleteAsync(inbox);
        }
    }
}
