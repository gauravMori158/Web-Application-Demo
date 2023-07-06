using DemoProject.Models;

namespace DemoProject.Interface
{
    public interface IDepartment
    {
        void AddDepartment(Department department);
        Department GetDepartmentById(int departmentId);
        List<Department> GetAllDepartment();
        void DeleteDepartment(Department department);
        void UpdateDepartment(Department department);
    }
}
