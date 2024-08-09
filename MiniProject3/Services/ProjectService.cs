using Microsoft.EntityFrameworkCore;
using MiniProject3.Interfaces;
using MiniProject3.Models;

namespace MiniProject3.Services
{
    public class ProjectService:IProjectService
    {
        private readonly CompanyContext _context;

        public ProjectService(CompanyContext context)
        {
            _context = context;
        }

        public List<Project> GetAllProjects()
        {
            return _context.Projects.ToList();
        }

        public Project GetProjectById(int id)
        {
            return _context.Projects.Find(id);
        }

        public Project AddProject(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
            return project;
        }

        public Project UpdateProject(int id, Project project)
        {
            if (id != project.Projno)
            {
                return null;
            }

            _context.Entry(project).State = EntityState.Modified;
            _context.SaveChanges();
            return project;
        }

        public bool DeleteProject(int id)
        {
            var project = _context.Projects.Find(id);
            if (project == null)
            {
                return false;
            }

            _context.Projects.Remove(project);
            _context.SaveChanges();
            return true;
        }
    }
}
