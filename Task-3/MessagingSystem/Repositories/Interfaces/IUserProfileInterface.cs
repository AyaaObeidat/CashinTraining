using MessagingSystem.Models;

namespace MessagingSystem.Repositories.Interfaces
{
    public interface IUserProfileInterface : IGenericInterface<UserProfile>
    {
        public Task<UserProfile> GetByUserEmail(string email);
    }

}
