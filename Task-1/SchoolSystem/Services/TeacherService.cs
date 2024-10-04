using SchoolSystem.Data;
using SchoolSystem.Dtos.StudentDtos;
using SchoolSystem.Dtos.SubjectDtos;
using SchoolSystem.Dtos.TeacherDtos;
using SchoolSystem.Models;

namespace SchoolSystem.Services
{
    public class TeacherService
    {
        private readonly SchoolSystemDbContext dbContext;

        public TeacherService(SchoolSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //=====================================================
        public Teacher Create(TeacherCreateParameters parameters)
        {
            var teacher = Teacher.Create(parameters.FullName, parameters.SchoolId , parameters.IsManager);
            dbContext.Teachers.Add(teacher);
            dbContext.SaveChanges();
            return teacher;
        }

        //=====================================================
        public List<TeacherDetails> Details()
        {
            var teachers = dbContext.Teachers.Select(x => new TeacherDetails()
            {
                Id = x.Id,
                SchoolId = x.SchoolId,
                FullName = x.FullName,
                IsManager = x.IsManager,
            }).ToList();

            return teachers;
        }

        //=====================================================
        public List<TeacherListItem> List()
        {
            var teachers = dbContext.Teachers.Select(x => new TeacherListItem()
            {
                FullName = x.FullName,
                Id = x.Id

            }).ToList();

            return teachers;
        }
        //=====================================================
        public Teacher GetById(Guid id)
        {
            var teacher = dbContext.Teachers.FirstOrDefault(x => x.Id == id);
            if (teacher == null) return null;
            return teacher;
        }
        //=====================================================
        public int Delete(Guid id)
        {
            var teacher = dbContext.Teachers.FirstOrDefault(x => x.Id == id);
            if (teacher == null) { return -1; }
            dbContext.Teachers.Remove(teacher);
            dbContext.SaveChanges();
            return 0;
        }
        //=====================================================
        public Teacher Update(TeacherUpdateParameters parameters)
        {
            var teacher = dbContext.Teachers.FirstOrDefault(x => x.Id == parameters.Id);
            if (teacher == null) { return null; }
            teacher = teacher.UpdateAll(parameters.FullName, parameters.SchoolId);
            dbContext.SaveChanges();
            return teacher;
        }
    }
}
