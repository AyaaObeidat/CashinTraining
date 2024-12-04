using Microsoft.EntityFrameworkCore;
using Profolio.Data;
using Profolio.Models;
using Profolio.Repositories.Interfaces;

namespace Profolio.Repositories.Implementations
{
    public class ExperienceInterface : GenericInterface<Experience>, IExperienceInterface
    {
        public ExperienceInterface(ProfolioDbContext dbContext) : base(dbContext)
        {
        }
    }
}
