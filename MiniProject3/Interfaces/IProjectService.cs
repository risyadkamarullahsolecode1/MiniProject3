using MiniProject3.Models;

namespace MiniProject3.Interfaces
{
    public interface IProjectService
    {
        List<Project> GetAllProjects();
        Project GetProjectById(int id);
        Project AddProject(Project project);
        Project UpdateProject(int id, Project project);
        bool DeleteProject(int id);
    }
}
