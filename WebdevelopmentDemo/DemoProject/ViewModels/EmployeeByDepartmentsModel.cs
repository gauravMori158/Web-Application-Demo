using DemoProject.Models;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.Pkcs;

namespace DemoProject.ViewModels
{
    public class EmployeeByDepartmentsModel
    {
        [Display(Name ="Department Name")]
        public string DepartmentName { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
