namespace SchoolSystem.Dtos.SubjectDtos
{
    public class SubjectUpdateParameters
    {
        public int Mark { get;  set; }
        public Guid StudentId { get;  set; }
        public Guid TeacherId { get;  set; }
        public Guid SchoolId { get;  set; }
    }
}
