using DemoProject.Interface;
using DemoProject.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DemoProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employees;
        private readonly IDepartment _department;
        private readonly IProject _project;
        private readonly IValidator<Employee> _validator;
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(IEmployee employee,IDepartment department,IProject project,IValidator<Employee> validator,ILogger<EmployeeController> logger) 
        {
            _employees = employee;
            _department = department;
            _project = project;
            _validator = validator;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View(_employees.GetAllEmployees());
        }
        [HttpGet]
        public IActionResult Create() 
        {
             ViewBag.DepartmentId = new SelectList(_department.GetAllDepartment(), "DepartmentId", "DepartmentName");
             ViewBag.ProjectId = new SelectList(_project.GetAllProjects(), "ProjectId", "ProjectName");
            _logger.LogInformation("Create method of employee is called\n");
             return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            var result = _validator.Validate(employee);
            
            if(result.IsValid)
            {
                _employees.AddEmployee(employee);
                _logger.LogInformation("Employee added successfully\n");
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(_department.GetAllDepartment(), "DepartmentId", "DepartmentName");
            ViewBag.ProjectId = new SelectList(_project.GetAllProjects(), "ProjectId", "ProjectName");
            foreach (var error in result.Errors)
            {
                _logger.LogInformation($"Error in validation while adding emplpoyee ERROR:{error}\n");
                ModelState.AddModelError("", error.ErrorMessage);
            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            _logger.LogInformation("Edit method of emplpoyee is called\n");
            ViewBag.DepartmentId = new SelectList(_department.GetAllDepartment(), "DepartmentId", "DepartmentName");
            ViewBag.ProjectId = new SelectList(_project.GetAllProjects(), "ProjectId", "ProjectName");
            Employee employee = _employees.GetEmployeeById(id);
            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if(ModelState.IsValid)
            {
                _employees.UpdateEmplpoyee(employee);
                _logger.LogInformation("Employee edited successfully.\n");
                return RedirectToAction("Index");
            }
            _logger.LogInformation("Error while editing employee\n");
            return View(employee);
        }
        public IActionResult Details(int id)
        {
            Employee employee = _employees.GetEmployeeById(id);
            return View(employee);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("Delete method of employee is called\n");
            Employee employee =  _employees.GetEmployeeById(id);
            return View(employee);
            
        }
        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            _employees.DeleteEmployee(employee);
            _logger.LogInformation($"Employee deleted successfully with id {employee.EmployeeId}\n");
            return RedirectToAction("Index");
        }

        public IActionResult GetAllEmplpoyeeByDepartment()
        {
            var employees = _employees.GetEmplpoyeeByDepartment();
            return View(employees);
        }

    }
}
