using Microsoft.EntityFrameworkCore;
using Profolio.Models;
using Profolio.Repositories.Interfaces;

namespace Profolio.Repositories.Implementations
{
    public class SkillsInterface : GeneralInterface<Skills>, ISkillsInterface
    {
        public SkillsInterface(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
