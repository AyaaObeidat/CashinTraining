using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using SchoolSystem.Data;
using SchoolSystem.Dtos.SchoolDtos;
using SchoolSystem.Models;
using System.Runtime.InteropServices;

namespace SchoolSystem.Services
{
    public class SchoolService
    {
       private readonly SchoolSystemDbContext dbContext;

        public SchoolService(SchoolSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //=====================================================
        public School Create(SchoolCreateParameters parameters)
        {
            var school = School.Create(parameters.Name, parameters.Description);
            dbContext.Schools.Add(school);
            dbContext.SaveChanges();
            return school;
        }

        //=====================================================
        public List<SchoolDetails> Details()
        {
            var schools = dbContext.Schools.Select(x => new SchoolDetails()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                ManagerTeacherId = x.ManagerTeacherId,
            }).ToList();

            return schools;
        }

        //=====================================================
        public List <SchoolListItem> List()
        {
            var schools = dbContext.Schools.Select(x => new SchoolListItem()
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();

            return schools;
        }
        //=====================================================
        public School GetById(Guid id)
        {
            var school = dbContext.Schools.FirstOrDefault(x => x.Id == id);
            if (school == null) return null;
            return school;
        }
        //=====================================================
        public int Delete(Guid id)
        {
            var school = dbContext.Schools.FirstOrDefault(x => x.Id == id);
            if(school == null) { return -1; }
            dbContext.Schools.Remove(school);
            dbContext.SaveChanges();
            return 0;
        }
        //=====================================================
       public School Update(SchoolUpdateParameters parameters)
        {
            var school = dbContext.Schools.FirstOrDefault(x => x.Id == parameters.Id);
            if(school == null) { return null; }
            school  = school.UpdateAll(parameters.Name , parameters.Description);
            return school;
        }
        //=====================================================
        public School UpdateManager(Guid schoolId, Guid managerId)
        {
            var school = dbContext.Schools.FirstOrDefault(x => x.Id == schoolId);
            if(school == null) { return null; }

            var newManager = dbContext.Teachers.FirstOrDefault(x => x.SchoolId == schoolId && x.Id == managerId);
            if (newManager == null) { return null; }

            var oldManager = dbContext.Teachers.FirstOrDefault(y => y.IsManager == true && y.SchoolId == schoolId);
            if (oldManager == null) { return null; }

            oldManager.UpdateIsManager(false);
            newManager.UpdateIsManager(true);
            school.SetManagerTeacherId(managerId);

            dbContext.SaveChanges();
            return school;

        }
    }
}
