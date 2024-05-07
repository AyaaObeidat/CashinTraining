using System.ComponentModel.DataAnnotations;

namespace Mahali.Models
{
    public class Category
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; private set; } = null!;

        private Category() { }
        private Category(string name)
        {
            Name = name;
        }

        public static Category Create(string name) 
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException();
            return new Category(name);
        }

        public void SetName(string name) 
        { 
            Name = name;
        }   
    }
}
