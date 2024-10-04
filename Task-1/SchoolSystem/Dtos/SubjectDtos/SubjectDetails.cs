namespace SchoolSystem.Dtos.SubjectDtos
{
    public class SubjectDetails
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Mark { get; set; }
        public Guid StudentId { get; set; }
        public Guid TeacherId { get; set; }
        public Guid SchoolId { get; set; }

    }
}
