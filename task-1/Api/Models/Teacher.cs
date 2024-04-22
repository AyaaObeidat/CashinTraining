namespace Api.Models;

public class Teacher
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public Guid SchoolId { get; set; }
    public bool IsManager { get; set; }

    private Teacher()
    {

    }
    private Teacher(Guid schoolId, string name, string email)
    {
        Id = Guid.NewGuid();
        SchoolId = schoolId;
        Name = name;
        Email = email;
    }

    public static Teacher Create(Guid schoolId, string name, string email)
    {
        return new Teacher(schoolId, name, email);
    }

    public void SetAsManager()
    {
        IsManager = true;
    }
}