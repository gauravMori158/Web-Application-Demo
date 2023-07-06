using System.ComponentModel.DataAnnotations;

namespace DemoProject.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get;set; }
        [Required]
        [Display(Name ="Project Name")]
        [RegularExpression(@"^[a-zA-Z0-9_ ]+$",ErrorMessage ="Project name contains alphabets and numbers.")]
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public ICollection<Employee>? Employees { get; set; }

    }
}
