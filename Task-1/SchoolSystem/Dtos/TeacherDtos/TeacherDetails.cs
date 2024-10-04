namespace SchoolSystem.Dtos.TeacherDtos
{
    public class TeacherDetails
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } 
        public bool IsManager { get; set; }
        public Guid SchoolId { get;  set; }

    }
}
