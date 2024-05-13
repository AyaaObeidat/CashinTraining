using Mahali.Models;

namespace Mahali.Repositories.Interfaces
{
    public interface IShopInterface : IGenericInterface<Shop>
    {
        public Task<Shop> GetByNameAsync(string name);
    }

}
