namespace SchoolSystem.Dtos.TeacherDtos
{
    public class TeacherUpdateParameters
    {
        public Guid Id { get; set; }
        public string FullName { get;  set; } 
        public Guid SchoolId { get; private set; }
    }
}
