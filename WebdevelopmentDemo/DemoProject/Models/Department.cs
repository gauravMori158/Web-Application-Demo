using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DemoProject.Models
{
    public class Department
    {
        [Key]
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        
        [RegularExpression(@"^([a-zA-Z._ ]{3,20})")]
        public string DepartmentName { get; set; }
        public ICollection<Employee>? Employees { get; set; }
    }
}
