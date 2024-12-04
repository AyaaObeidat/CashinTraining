using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Profolio.Services;
using ProfolioDtos.SkillsDtos;
using ProfolioDtos.UserDtos;

namespace Profolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly SkillsService _skillService;

        public SkillsController(SkillsService skillService)
        {
            _skillService = skillService;
        }

        [HttpPost]
        [Route("AddSkills")]
        public async Task<IActionResult> AddAsync([FromBody] SkillsCreateParameters parameters)
        {
            await _skillService.AddSkillsAsync(parameters);
            return Ok();
        }


        [HttpDelete]
        [Route("DeleteSkills")]
        public async Task<IActionResult> DeleteAsync([FromBody] SkillsGetByParameter parameters)
        {
            await _skillService.DeleteSkillsAsync(parameters);
            return Ok();
        }


        [HttpPost]
        [Route("GetAllUserSkills")]
        public async Task<IActionResult> GetAllUserSkillsAsync([FromBody] UserGetByParameters parameters)
        {
            return Ok(await _skillService.GetAllUserSkills(parameters));
        }


        [HttpPost]
        [Route("GetSkillsById")]
        public async Task<IActionResult> GetSkillsByIdAsync([FromBody] SkillsGetByParameter parameters)
        {
            return Ok(await _skillService.GetSkillsByIdAsync(parameters));
        }

        [HttpPatch]
        [Route("ModifyTitle")]
        public async Task<IActionResult> ModifyTitleAsync([FromBody] SkillsUpdateParameters parameters)
        {
            await _skillService.ModifyTitle(parameters);
            return Ok();
        }


        [HttpPatch]
        [Route("ModifyDescription")]
        public async Task<IActionResult> ModifyDescriptionAsync([FromBody] SkillsUpdateParameters parameters)
        {
            await _skillService.ModifyDescription(parameters);
            return Ok();
        }

    }
}
