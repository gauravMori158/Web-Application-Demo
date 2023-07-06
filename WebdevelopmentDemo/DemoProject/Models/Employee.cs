using Humanizer.Localisation.DateToOrdinalWords;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoProject.Models
{
    public class Employee
    {
        [Key]
        [Required] 
        public int EmployeeId { get; set; }
        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z ]+$",ErrorMessage ="First Name contains only alphabets.")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Last Name contains only alphabets.")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Date),DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }


        [Required]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime JoiningDate { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get;set; }
        public Department? Departments { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public Project? Projects { get; set; }
    }
}
