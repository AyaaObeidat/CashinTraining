namespace SchoolSystem.Dtos.StudentDtos
{
    public class StudentUpdateParameters
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public Guid SchoolId { get;  set; }
    }
}
