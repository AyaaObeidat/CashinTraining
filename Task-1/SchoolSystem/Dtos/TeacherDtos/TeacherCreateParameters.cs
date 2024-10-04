namespace SchoolSystem.Dtos.TeacherDtos
{
    public class TeacherCreateParameters
    {
        public string FullName { get; set; }
        public bool IsManager { get;  set; }
        public Guid SchoolId { get;  set; }
    }
}
