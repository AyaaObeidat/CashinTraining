using SchoolSystem.Data;
using SchoolSystem.Dtos.SchoolDtos;
using SchoolSystem.Dtos.SubjectDtos;
using SchoolSystem.Models;

namespace SchoolSystem.Services
{
    public class SubjectService
    {
        private readonly SchoolSystemDbContext dbContext;

        public SubjectService(SchoolSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //=====================================================
        public Subject Create(SubjectCreateParameters parameters)
        {
            var subject = Subject.Create(parameters.Name , parameters.Mark , parameters.StudentId , parameters.SchoolId , parameters.TeacherId);
            dbContext.Subjects.Add(subject);
            dbContext.SaveChanges();
            return subject;
        }

        //=====================================================
        public List<SubjectDetails> Details()
        {
            var subjects = dbContext.Subjects.Select(x => new SubjectDetails()
            {
                Id = x.Id,
                Name = x.Name,
                Mark = x.Mark,
                StudentId = x.StudentId,
                SchoolId = x.SchoolId,
                TeacherId = x.TeacherId,
            }).ToList();

            return subjects;
        }

        //=====================================================
        public List<SubjectListItem> List()
        {
            var subjects = dbContext.Subjects.Select(x => new SubjectListItem()
            {
                Name= x.Name,
                Mark = x.Mark,

            }).ToList();

            return subjects;
        }
        //=====================================================
        public List<Subject> GetById(Guid studentId)
        {
            var subjects = dbContext.Subjects.Where(x => x.StudentId == studentId);
            if (subjects == null) return null;
            return subjects.ToList();
        }
        
        //=====================================================
        public int Delete(Guid studentId , string subjectName)
        {
            var subject = dbContext.Subjects.FirstOrDefault(x => x.StudentId == studentId && x.Name==subjectName);
            if (subject == null) { return -1; }
            dbContext.Subjects.Remove(subject);
            dbContext.SaveChanges();
            return 0;
        }
        //=====================================================
        public Subject UpdateMark(SubjectUpdateParameters parameters)
        {
            var subject = dbContext.Subjects.FirstOrDefault(x => x.StudentId==parameters.StudentId && x.SchoolId==parameters.SchoolId && x.TeacherId==parameters.TeacherId);
            if (subject == null) { return null; }
            subject = subject.UpdateMark(parameters.Mark);
            dbContext.SaveChanges();
            return subject;
        }
       
       
    }
}
