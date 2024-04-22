using System.Reflection;

namespace SchoolSystem.Models
{
    public class Teacher
    {
        public Guid Id { get; set; }
        public string FullName { get; private set; } = null!;
        public bool IsManager { get; private set; }
        public Guid SchoolId { get; private set; }

        //==========================================================
        private Teacher() { }
        private Teacher(string fullName, Guid schoolId)
        {
            FullName = fullName;
            SchoolId = schoolId;
            IsManager = false;

        }
        //===========================================================

        public static Teacher Create(string fullName , Guid schoolId)
        {
            if (string.IsNullOrEmpty(fullName)) throw new ArgumentNullException();

            return new Teacher(fullName , schoolId);
        }


        public void UpdateIsManager(bool isManager)
        {
            IsManager = isManager;
        }
        public Teacher UpdateName(string fullName)
        {
            FullName = fullName;
            return this;
        }
        public Teacher UpdateTeacherSchool(Guid schoolId)
        {
            SchoolId = schoolId;
            return this;
        }
        public Teacher UpdateAll(string fullName, Guid schoolId)
        {
            FullName = fullName;
            SchoolId = schoolId;
            return this;
        }

    }
}
