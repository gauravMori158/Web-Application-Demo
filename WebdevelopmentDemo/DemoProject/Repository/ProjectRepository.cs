using DemoProject.Interface;
using DemoProject.Models;

namespace DemoProject.Repository
{
    public class ProjectRepository : IProject
    {
        private readonly EmployeeDBContext _dbContext;
        public ProjectRepository(EmployeeDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public void AddProject(Project project)
        {
            _dbContext.Projects.Add(project);
            _dbContext.SaveChanges();
        }

        public void DeleteProject(Project project)
        {
            _dbContext.Projects.Remove(project);
            _dbContext.SaveChanges();
        }

        public List<Project> GetAllProjects()
        {
            return _dbContext.Projects.ToList();
        }

        public Project GetProjectById(int projectId)
        {
            Project project = _dbContext.Projects.SingleOrDefault(p => p.ProjectId == projectId);
            return project;
        }

        public void UpdateProject(Project project)
        {
            Project updateProject = _dbContext.Projects.SingleOrDefault(p => p.ProjectId == project.ProjectId);

            updateProject.ProjectName = project.ProjectName;
            updateProject.Description = project.Description;

            _dbContext.SaveChanges();
        }
    }
}
