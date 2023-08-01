using Microsoft.EntityFrameworkCore;
using StudentRegistration.Models;

namespace StudentRegistration.Data
{
    public class StudentProfileDbContext : DbContext
    {
        public StudentProfileDbContext(DbContextOptions<StudentProfileDbContext> options)
            : base(options) 
        {

        }
        public DbSet<Course> Courses { get; set; }
    }
}
