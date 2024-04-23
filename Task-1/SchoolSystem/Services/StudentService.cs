using SchoolSystem.Data;
using SchoolSystem.Dtos.SchoolDtos;
using SchoolSystem.Dtos.StudentDtos;
using SchoolSystem.Models;

namespace SchoolSystem.Services
{
    public class StudentService
    {
        private readonly SchoolSystemDbContext dbContext;

        public StudentService(SchoolSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //=====================================================
        public Student Create(StudentCreateParameters parameters)
        {
            var student = Student.Create(parameters.FullName , parameters.SchoolId);
            dbContext.Students.Add(student);
            dbContext.SaveChanges();
            return student;
        }

        //=====================================================
        public List<StudentDetails> Details()
        {
            var students = dbContext.Students.Select(x => new StudentDetails()
            {
                Id = x.Id,
                SchoolId = x.SchoolId,
                FullName = x.FullName,
            }).ToList();

            return students;
        }

        //=====================================================
        public List<StudentListItem> List()
        {
            var students = dbContext.Students.Select(x => new StudentListItem()
            {
                FullName = x.FullName,
                Id = x.Id

            }).ToList();

            return students;
        }
        //=====================================================
        public Student GetById(Guid id)
        {
            var student = dbContext.Students.FirstOrDefault(x => x.Id == id);
            if (student == null) return null;
            return student;
        }
        //=====================================================
        public int Delete(Guid id)
        {
            var student = dbContext.Students.FirstOrDefault(x => x.Id == id);
            if (student == null) { return -1; }
            dbContext.Students.Remove(student);
            dbContext.SaveChanges();
            return 0;
        }
        //=====================================================
        public Student Update(StudentUpdateParameters parameters)
        {
            var student = dbContext.Students.FirstOrDefault(x => x.Id == parameters.Id);
            if (student == null) { return null; }
            student = student.UpdateAll(parameters.FullName , parameters.SchoolId);
            dbContext.SaveChanges();
            return student;
        }
    }
}
