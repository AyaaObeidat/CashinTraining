using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Dtos.SchoolDtos;
using SchoolSystem.Services;

namespace SchoolSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolServiceController : ControllerBase
    {
        private readonly SchoolService _schoolService;

        public SchoolServiceController(SchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        //================================================
        [HttpPost]
        [Route("Add")]
        public IActionResult Add( [FromBody] SchoolCreateParameters parameters)
        {
            var school = _schoolService.Create(parameters);
            if(school == null) { return NotFound(); }   
            return Ok(school);
        }
        //================================================
        [HttpGet]
        [Route("GetAll/Details")]
        public IActionResult GetSchoolsDetails()
        {
            var schools = _schoolService.Details();
            if(schools.Count ==0) { return NotFound(); }
            return Ok(schools);
        }
        //================================================
        [HttpGet]
        [Route("GetAll/List")]
        public IActionResult GetSchoolsListItem()
        {
            var schools = _schoolService.List();
            if (schools.Count == 0) { return NotFound(); }
            return Ok(schools);
        }
        //================================================ 
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(Guid id)
        {
            var school = _schoolService.GetById(id);
            if (school == null) { return NotFound(); }
            return Ok(school);
        }
        //================================================
        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(Guid id)
        {
            int result = _schoolService.Delete(id);
            if(result == -1) { return NotFound(); }
            return Ok();

        }
        //================================================
        [HttpPatch]
        [Route("Update")]
        public IActionResult Update(SchoolUpdateParameters parameters)
        {
            var school = _schoolService.Update(parameters);
            if(school == null) { return NotFound(); }
            return Ok(school);
        }
        //================================================
        [HttpPatch]
        [Route("UpdateManager")]
        public IActionResult UpdateManager(Guid schoolId , Guid managerId)
        {
            var school = _schoolService.UpdateManager(schoolId, managerId);
            if(school == null) { return NotFound(); }
            return Ok(school);
        }
    }
}
