using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Dtos.SchoolDtos;
using SchoolSystem.Dtos.TeacherDtos;
using SchoolSystem.Services;

namespace SchoolSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherServiceController : ControllerBase
    {
        private readonly TeacherService _teacherService;

        public TeacherServiceController(TeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        //================================================
        [HttpPost]
        [Route("Add")]
        public IActionResult Add([FromBody] TeacherCreateParameters parameters)
        {
            var teacher = _teacherService.Create(parameters);
            if (teacher == null) { return NotFound(); }
            return Ok(teacher);
        }
        //================================================
        [HttpGet]
        [Route("GetAll/Details")]
        public IActionResult GetTeachersDetails()
        {
            var teachers = _teacherService.Details();
            if (teachers.Count == 0) { return NotFound(); }
            return Ok(teachers);
        }
        //================================================
        [HttpGet]
        [Route("GetAll/List")]
        public IActionResult GetTeachersListItem()
        {
            var teachers = _teacherService.List();
            if (teachers.Count == 0) { return NotFound(); }
            return Ok(teachers);
        }
        //================================================ 
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(Guid teacherId)
        {
            var teacher = _teacherService.GetById(teacherId);
            if (teacher == null) { return NotFound(); }
            return Ok(teacher);
        }
        //================================================
        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(Guid id)
        {
            int result = _teacherService.Delete(id);
            if (result == -1) { return NotFound(); }
            return Ok();

        }
        //================================================
        [HttpPatch]
        [Route("Update")]
        public IActionResult Update(TeacherUpdateParameters parameters)
        {
            var teacher = _teacherService.Update(parameters);
            if (teacher == null) { return NotFound(); }
            return Ok(teacher);
        }
        
    }
}
