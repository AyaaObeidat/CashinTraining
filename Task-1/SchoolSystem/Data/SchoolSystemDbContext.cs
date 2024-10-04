using Microsoft.EntityFrameworkCore;
using SchoolSystem.Models;

namespace SchoolSystem.Data
{
    public class SchoolSystemDbContext : DbContext
    {
        public SchoolSystemDbContext() { }

        public SchoolSystemDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        public DbSet<School> Schools { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}
