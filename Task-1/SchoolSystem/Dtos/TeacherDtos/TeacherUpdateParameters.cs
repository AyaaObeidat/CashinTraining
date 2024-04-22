namespace SchoolSystem.Dtos.TeacherDtos
{
    public class TeacherUpdateParameters
    {
        public string FullName { get; private set; } = null!;
        public bool IsManager { get; private set; }
        public Guid SchoolId { get; private set; }
    }
}
