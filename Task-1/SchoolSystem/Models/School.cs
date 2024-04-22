namespace SchoolSystem.Models
{
    public class School
    {
        
        public Guid Id { get; set; }
        public string Name { get; private set; } = null!;
        public string Description { get; private set; } = null!;
        public Guid ManagerTeacherId { get; private set; }

        //===================================================
        private School() { }
        private School(string name, string description)
        {
            Name = name;
            Description = description;
        }

        //===================================================

        public static School Create(string name, string description)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException();
            if (string.IsNullOrEmpty(description)) throw new ArgumentNullException();

            return new School(name, description);
        }

        public void SetManagerTeacherId(Guid managerTeacherId)
        {
            ManagerTeacherId = managerTeacherId;
        }

        public School UpdateName(string name)
        {
            Name = name;
            return this;
        }
        public School UpdateDesc(string description)
        {
            Description = description;
            return this;
        }

        public School UpdateAll(string name , string description)
        {
            Name = name;
            Description = description;
            return this;
        }
    }
}
