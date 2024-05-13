using Mahali.Models;

namespace Mahali.Repositories.Interfaces
{
    public interface IAdminInterface : IGenericInterface<Admin>
    {
        public  Task<Admin> GetByUserName(string userName);
        public  Task<string> GetUserName();
    }
}
