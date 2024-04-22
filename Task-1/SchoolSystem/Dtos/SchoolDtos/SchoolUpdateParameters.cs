namespace SchoolSystem.Dtos.SchoolDtos
{
    public class SchoolUpdateParameters
    {
        public string Name { get; private set; } = null!;
        public string Description { get; private set; } = null!;
        public Guid ManagerTeacherId { get; private set; }
    }
}
