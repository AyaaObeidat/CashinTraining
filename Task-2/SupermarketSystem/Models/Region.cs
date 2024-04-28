namespace SupermarketSystem.Models
{
    public class Region
    {
        public Guid Id { get;  set; }
        public string Name { get; private set; } = null!;
        private Region() { }
        private Region(string name)
        {
            
            Name = name;
        }

        public static Region Create( string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException();
            return new Region( name);
        }
        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name)) { throw new ArgumentNullException(); }
            Name = name;
        }
    }
}
