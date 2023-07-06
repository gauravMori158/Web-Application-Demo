using Microsoft.EntityFrameworkCore;

namespace DemoProject.Models
{
    public class EmployeeDBContext:DbContext
    {
        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options):base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set;}
        public DbSet<Department> Departments { get; set;}   
        public DbSet<Project> Projects { get; set;} 
    }
}
