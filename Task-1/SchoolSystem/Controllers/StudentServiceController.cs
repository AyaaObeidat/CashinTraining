using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Dtos.SchoolDtos;
using SchoolSystem.Dtos.StudentDtos;
using SchoolSystem.Services;

namespace SchoolSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentServiceController : ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentServiceController(StudentService studentService)
        {
            _studentService = studentService;
        }

        //================================================
        [HttpPost]
        [Route("Add")]
        public IActionResult Add([FromBody] StudentCreateParameters parameters)
        {
            var student = _studentService.Create(parameters);
            if (student == null) { return NotFound(); }
            return Ok(student);
        }
        //================================================
        [HttpGet]
        [Route("GetAll/Details")]
        public IActionResult GetSchoolsDetails()
        {
            var students = _studentService.Details();
            if (students.Count == 0) { return NotFound(); }
            return Ok(students);
        }
        //================================================
        [HttpGet]
        [Route("GetAll/List")]
        public IActionResult GetSchoolsListItem()
        {
            var students = _studentService.List();
            if (students.Count == 0) { return NotFound(); }
            return Ok(students);
        }
        //================================================
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(Guid studentId)
        {
            var student = _studentService.GetById(studentId);
            if (student == null) { return NotFound(); }
            return Ok(student);
        }
        
        //================================================
        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(Guid id)
        {
            int result = _studentService.Delete(id);
            if (result == -1) { return NotFound(); }
            return Ok();

        }
        //================================================
        [HttpPatch]
        [Route("Update")]
        public IActionResult Update(StudentUpdateParameters parameters)
        {
            var student = _studentService.Update(parameters);
            if (student == null) { return NotFound(); }
            return Ok(student);
        }
    }
}
