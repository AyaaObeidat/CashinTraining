namespace SchoolSystem.Models
{
    public class Subject
    {
        public Guid Id { get; set; }
        public string Name { get; private set; } = null!;
        public int Mark { get; private set; }
        public Guid StudentId { get; private set; }
        public Guid TeacherId { get; private set; }
        public Guid SchoolId { get; private set; }

        //=====================================================================
        public Subject() { }
        public Subject(string name, int mark, Guid studentId, Guid schoolId, Guid teacherId)
        {
            Name = name;
            Mark = mark;
            StudentId = studentId;
            SchoolId = schoolId;
            TeacherId = teacherId;
        }
        //=====================================================================
        public static Subject Create(string name, int mark , Guid studentId , Guid schoolId , Guid teacherId)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("name");
            if (mark < 0 || mark > 100) throw new ArgumentOutOfRangeException();
            return new Subject(name, mark , studentId,schoolId,teacherId);
        }
       
        public Subject UpdateMark(int mark)
        {
            Mark = mark;
            return this;
        }
    }
}
