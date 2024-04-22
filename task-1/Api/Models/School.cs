namespace Api.Models;

public class School
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public Guid? ManagerId { get; set; }

    private School()
    {
        
    }
    private School(string title)
    {
        Id = Guid.NewGuid();
        Title = title;
    }

    public static School Create(string title)
    {
        return new School(title);
    }

    public void SetManager(Guid mangerId)
    {
        ManagerId = mangerId;
    }
}
