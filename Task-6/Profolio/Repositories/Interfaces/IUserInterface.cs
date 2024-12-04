using Profolio.Models;

namespace Profolio.Repositories.Interfaces
{
    public interface IUserInterface : IGenericInterface<User>
    {
        public Task<List<User>> GetAllPublicUsersAsync();
    }
}
