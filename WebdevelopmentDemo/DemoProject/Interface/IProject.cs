using DemoProject.Models;

namespace DemoProject.Interface
{
    public interface IProject
    {
        void AddProject(Project project);
        Project GetProjectById(int projectId);
        List<Project> GetAllProjects();
        void DeleteProject(Project project);
        void UpdateProject(Project project);
    }
}
