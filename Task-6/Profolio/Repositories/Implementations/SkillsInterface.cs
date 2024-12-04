using Microsoft.EntityFrameworkCore;
using Profolio.Data;
using Profolio.Models;
using Profolio.Repositories.Interfaces;

namespace Profolio.Repositories.Implementations
{
    public class SkillsInterface : GenericInterface<Skills>, ISkillsInterface
    {
        public SkillsInterface(ProfolioDbContext dbContext) : base(dbContext)
        {
        }
    }
}
