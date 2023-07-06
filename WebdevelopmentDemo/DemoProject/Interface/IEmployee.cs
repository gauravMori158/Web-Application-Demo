using DemoProject.Models;
using DemoProject.ViewModels;

namespace DemoProject.Interface
{
    public interface IEmployee
    {
        Employee GetEmployeeById(int employeeId);
        List<Employee> GetAllEmployees();
        void UpdateEmplpoyee(Employee employee);
        void DeleteEmployee(Employee employee);
        void AddEmployee(Employee employee);
        List<EmployeeByDepartmentsModel> GetEmplpoyeeByDepartment();
    }
}
