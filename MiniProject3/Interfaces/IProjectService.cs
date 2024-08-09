using MiniProject3.Models;

namespace MiniProject3.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAllProjects();
        Task<Project> GetProjectById(int id);
        Task<Project> AddProject(Project project);
        Task<Project> UpdateProject(int id, Project project);
        Task<bool> DeleteProject(int id);

        //method
        Task<IEnumerable<Project>> GetProjectsManagedByPlanning();
        Task<IEnumerable<Project>> GetProjectsWithNoEmployees();
        Task<IEnumerable<object>> GetProjectsManagedByFemaleManagers();
    }
}
