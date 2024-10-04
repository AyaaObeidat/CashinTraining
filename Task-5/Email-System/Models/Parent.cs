namespace Email_System.Models
{
    public abstract class Parent
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }

        public Parent() { }
        public void SetCreatedDate()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
