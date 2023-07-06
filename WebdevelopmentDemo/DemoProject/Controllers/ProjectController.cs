using DemoProject.Interface;
using DemoProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProject _projects;
        public ProjectController(IProject project) 
        {
            _projects = project;
        }
        public IActionResult Index()
        {
            return View(_projects.GetAllProjects());
        }
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        public IActionResult Create(Project project)
        {
            if(ModelState.IsValid)
            {
                _projects.AddProject(project);
                return RedirectToAction("Index");
            }
            return View(project);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Project project = _projects.GetProjectById(id);
            return View(project);   
        }

        [HttpPost]
        public IActionResult Delete(Project project)
        {
            _projects.DeleteProject(project);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {   
            Project project =  _projects.GetProjectById(id);
            return View(project);
        }
        [HttpPost]
        public IActionResult Edit(Project project)
        {
            if(ModelState.IsValid)
            {
                _projects.UpdateProject(project);
                return RedirectToAction("Index");
            }
            return View(project);
        }
        public IActionResult Details(int id)
        {
            return View(_projects.GetProjectById(id));
        }
    }
}
