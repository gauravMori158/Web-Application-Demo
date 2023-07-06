using DemoProject.Interface;
using DemoProject.Models;

namespace DemoProject.Repository
{
    public class DepartmentRepository : IDepartment
    {
        private readonly EmployeeDBContext _dbContext;
        public DepartmentRepository(EmployeeDBContext dBContext) 
        {
            _dbContext = dBContext;
        }
        public void AddDepartment(Department department)
        {
            _dbContext.Departments.Add(department);
            _dbContext.SaveChanges();
        }

        public void DeleteDepartment(Department department)
        {
            _dbContext.Departments.Remove(department);
            _dbContext.SaveChanges();
        }

        public List<Department> GetAllDepartment()
        {
            return _dbContext.Departments.ToList();
        }

        public Department GetDepartmentById(int departmentId)
        {
            Department department = _dbContext.Departments.SingleOrDefault(d => d.DepartmentId == departmentId);
            return department;
        }

        public void UpdateDepartment(Department department)
        {
            Department updateDepartment = _dbContext.Departments.SingleOrDefault(e => e.DepartmentId == department.DepartmentId);

            updateDepartment.DepartmentName = department.DepartmentName;
            _dbContext.SaveChanges();
        }
    }
}
