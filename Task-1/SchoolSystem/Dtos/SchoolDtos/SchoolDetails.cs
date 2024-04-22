namespace SchoolSystem.Dtos.SchoolDtos
{
    public class SchoolDetails
    {
        public Guid Id { get; set; }
        public string Name { get;  set; }
        public string Description { get; set; } 
        public Guid ManagerTeacherId { get; set; }
    }
}
