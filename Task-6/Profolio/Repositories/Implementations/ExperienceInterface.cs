using Microsoft.EntityFrameworkCore;
using Profolio.Models;
using Profolio.Repositories.Interfaces;

namespace Profolio.Repositories.Implementations
{
    public class ExperienceInterface : GeneralInterface<Experience>, IExperienceInterface
    {
        public ExperienceInterface(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
