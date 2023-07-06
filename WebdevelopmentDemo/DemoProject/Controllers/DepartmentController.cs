using DemoProject.Interface;
using DemoProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartment _departments;
        public DepartmentController(IDepartment department)
        {
            _departments = department;
        }
        public IActionResult Index()
        {
            return View(_departments.GetAllDepartment());
        }
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)         
        {
            if(ModelState.IsValid)
            {
                _departments.AddDepartment(department);
                return RedirectToAction("Index");
            }
            return View(department);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Department department = _departments.GetDepartmentById(id);
            return View(department);
        }
        [HttpPost]
        public IActionResult Edit(Department department)
        {
            if(ModelState.IsValid)
            {
                _departments.UpdateDepartment(department);
                return RedirectToAction("Index");
            }
            return View(department);
        }
        public IActionResult Details(int id)
        {
            Department department =  _departments.GetDepartmentById(id);
            return View(department);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Department department = _departments.GetDepartmentById(id);
            return View(department);
        }
        [HttpPost]
        public IActionResult Delete(Department department)
        {
            _departments.DeleteDepartment(department);
            return RedirectToAction("Index");
        }
    }
}
