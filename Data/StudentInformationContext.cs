using StudentInformationThur.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentInformationThur.Data
{
    //Creates a new database context named StudentInformationContext
    public class StudentInformationContext : DbContext
    {
        public StudentInformationContext(DbContextOptions<StudentInformationContext> options) : base(options)
        {
        }

        //This is where we register our models as entities
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Camper> Campers { get; set; }
    }
}