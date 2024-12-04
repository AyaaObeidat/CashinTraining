using Profolio.Models;
using Profolio.Repositories.Interfaces;
using ProfolioDtos.SkillsDtos;
using ProfolioDtos.UserDtos;
using System.Reflection.Metadata;
namespace Profolio.Services
{
    public class SkillsService
    {
        private readonly ISkillsInterface _skillsInterface;
        private readonly IUserInterface _userInterface;

        public SkillsService(ISkillsInterface skillsInterface,IUserInterface userInterface)
        {
            _skillsInterface = skillsInterface;
            _userInterface = userInterface;
        }

        public async Task AddSkillsAsync(SkillsCreateParameters parameters)
        {
            var user = await _userInterface.GetByIdAsync(parameters.UserId);
            if (user == null) throw new ArgumentNullException("the user not found");
            var duplicateUserSkills = user.Skills.ToList().Where(s => s.Title == parameters.Title).ToList();
            if (duplicateUserSkills.Count > 0) throw new ArgumentException();
            else
            {
                var newSkills = Skills.Create(parameters.Title, parameters.UserId);
                await _skillsInterface.AddAsync(newSkills);
            }
            
        }

        public async Task DeleteSkillsAsync(SkillsGetByParameter parameter)
        {
            var skills = await _skillsInterface.GetByIdAsync(parameter.Id);
            if (skills == null) throw new ArgumentNullException();
            await _skillsInterface.DeleteAsync(parameter.Id);

        }

        public async Task<List<SkillsDetails>> GetAllUserSkills(UserGetByParameters parameters)
        {
            var user = await _userInterface.GetByIdAsync(parameters.Id);
            if(user == null) throw new ArgumentNullException("the user not found");
            return user.Skills.ToList().Select(s => new SkillsDetails
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description
            }).ToList();
        }

        public async Task<SkillsDetails> GetSkillsByIdAsync(SkillsGetByParameter parameter)
        {
            var skills = await _skillsInterface.GetByIdAsync(parameter.Id);
            if (skills == null) throw new ArgumentNullException();
            return new SkillsDetails
            {
                Id = skills.Id,
                Title = skills.Title,
                Description = skills.Description,
                UserId = skills.UserId,
            };

        }

        public async Task ModifyTitle(SkillsUpdateParameters parameters)
        {
            var skills = await _skillsInterface.GetByIdAsync(parameters.Id);
            if (skills == null) throw new ArgumentNullException();

            skills.SetTitle(parameters.NewTitle);
            await _skillsInterface.UpdateAsync(skills);
        }

        public async Task ModifyDescription(SkillsUpdateParameters parameters)
        {
            var skills = await _skillsInterface.GetByIdAsync(parameters.Id);
            if (skills == null) throw new ArgumentNullException();

            skills.SetDescription(parameters.NewDescription);
            await _skillsInterface.UpdateAsync(skills);
        }
    }
}
