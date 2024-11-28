using Microsoft.EntityFrameworkCore;
using Profolio.Models;
using Profolio.Repositories.Interfaces;

namespace Profolio.Repositories.Implementations
{
    public class ContactInterface : GeneralInterface<Contact>, IContactInterface
    {
        public ContactInterface(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
