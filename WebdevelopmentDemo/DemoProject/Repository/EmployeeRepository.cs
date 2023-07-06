using DemoProject.Interface;
using DemoProject.Models;
using DemoProject.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Repository
{
    public class EmployeeRepository : IEmployee
    {
        private readonly EmployeeDBContext _dbContext;
        public EmployeeRepository(EmployeeDBContext dbContext)
        {

            _dbContext = dbContext; 

        }
        public void AddEmployee(Employee employee)
        {
            _dbContext.Add(employee);
            _dbContext.SaveChanges();
        }

        public void DeleteEmployee(Employee employee)
        {
            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges();
        }

        public List<Employee> GetAllEmployees()
        {
            return _dbContext.Employees.Include(d => d.Departments).Include(p => p.Projects).ToList();
        }

        public Employee GetEmployeeById(int employeeId)
        {
            Employee employee = _dbContext.Employees.Include(d => d.Departments).Include(p => p.Projects).SingleOrDefault(e => e.EmployeeId == employeeId);
            return employee;
        }

        public List<EmployeeByDepartmentsModel> GetEmplpoyeeByDepartment()
        {
            var employees = _dbContext.Employees.Include(d => d.Departments).GroupBy(d => d.Departments.DepartmentName).
                Select(x => new EmployeeByDepartmentsModel() { DepartmentName = x.Key,Employees = x.ToList() }).ToList();
            return employees;
        }

        public void UpdateEmplpoyee(Employee employee)
        {
            Employee updateEmployee = _dbContext.Employees.Include(d => d.Departments).Include(p => p.Projects).SingleOrDefault(e => e.EmployeeId == employee.EmployeeId);

            updateEmployee.FirstName = employee.FirstName;
            updateEmployee.LastName = employee.LastName;
            updateEmployee.Email = employee.Email;
            updateEmployee.Address = employee.Address;
            updateEmployee.DateOfBirth  = employee.DateOfBirth;
            updateEmployee.JoiningDate = employee.JoiningDate;
            updateEmployee.DepartmentId = employee.DepartmentId;
            updateEmployee.Salary = employee.Salary;
            updateEmployee.DepartmentId = employee.DepartmentId;
            updateEmployee.ProjectId = employee.ProjectId;

            _dbContext.SaveChanges();
        }

       
    }
}
