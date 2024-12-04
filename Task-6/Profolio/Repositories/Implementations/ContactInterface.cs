using Microsoft.EntityFrameworkCore;
using Profolio.Data;
using Profolio.Models;
using Profolio.Repositories.Interfaces;

namespace Profolio.Repositories.Implementations
{
    public class ContactInterface : GenericInterface<Contact>, IContactInterface
    {
        public ContactInterface(ProfolioDbContext dbContext) : base(dbContext)
        {
        }
    }
}
