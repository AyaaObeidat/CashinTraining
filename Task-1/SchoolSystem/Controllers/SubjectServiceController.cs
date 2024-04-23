using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Dtos.SchoolDtos;
using SchoolSystem.Dtos.SubjectDtos;
using SchoolSystem.Services;

namespace SchoolSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectServiceController : ControllerBase
    {

            private readonly SubjectService _subjectService;

            public SubjectServiceController(SubjectService subjectService)
            {
            _subjectService = subjectService;
            }

            //================================================
            [HttpPost]
            [Route("Add")]
            public IActionResult Add([FromBody] SubjectCreateParameters parameters)
            {
                var subject = _subjectService.Create(parameters);
                if (subject == null) { return NotFound(); }
                return Ok(subject);
            }
            //================================================
            [HttpGet]
            [Route("GetAll/Details")]
            public IActionResult GetSchoolsDetails()
            {
                var subjects = _subjectService.Details();
                if (subjects.Count == 0) { return NotFound(); }
                return Ok(subjects);
            }
            //================================================
            [HttpGet]
            [Route("GetAll/List")]
            public IActionResult GetSchoolsListItem()
            {
                var subjects = _subjectService.List();
                if (subjects.Count == 0) { return NotFound(); }
                return Ok(subjects);
            }
            //================================================
            [HttpGet]
            [Route("GetById")]
            public IActionResult GetById(Guid studenId)
            {
            var subjectsOfStudent = _subjectService.GetById(studenId);
            if (subjectsOfStudent == null) { return NotFound(); }
            return Ok(subjectsOfStudent);
            }
            
            //================================================
            [HttpDelete]
            [Route("Delete")]
            public IActionResult Delete(Guid studentId, string subjectName)
            {
                int result = _subjectService.Delete(studentId,subjectName);
                if (result == -1) { return NotFound(); }
                return Ok();

            }
            //================================================
            [HttpPatch]
            [Route("Update")]
            public IActionResult Update(SubjectUpdateParameters parameters)
            {
                var subject = _subjectService.UpdateMark(parameters);
                if (subject == null) { return NotFound(); }
                return Ok(subject);
            }
            
        }
}
