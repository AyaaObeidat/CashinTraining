using System.Reflection;

namespace SchoolSystem.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public string FullName { get; private set; } = null!;
        public Guid SchoolId { get; private set; }

        //=====================================================

        private Student() { }
        private Student(string fullName , Guid schoolId)
        {
            FullName = fullName;
            SchoolId = schoolId;
        }

        //=====================================================
        public static Student Create(string fullName , Guid schoolId)
        {
            if (string.IsNullOrEmpty(fullName)) throw new ArgumentNullException();

            return new Student(fullName , schoolId);
        }
        public Student UpdateName(string fullName)
        {
            FullName = fullName;
            return this;
        }
        public Student UpdateStudentSchool( Guid schoolId)
        {
            SchoolId = schoolId;
            return this;
        }
        public Student UpdateAll(string fullName, Guid schoolId)
        {
            FullName = fullName;
            SchoolId = schoolId;
            return this;
        }

    }
}
