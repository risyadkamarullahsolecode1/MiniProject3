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

        public async Task<IEnumerable<Project>> GetAllProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> GetProjectById(int id)
        {
            return await _context.Projects.FindAsync(id);
        }

        public async Task<Project> AddProject(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<Project> UpdateProject(int id, Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<bool> DeleteProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return false;
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return true;
        }

        //method Get project managed by department named planning
        public async Task<IEnumerable<Project>> GetProjectsManagedByPlanning()
        {
            var planningDept = await _context.Departments
                .FirstOrDefaultAsync(d => d.Deptname == "Planning");

            if(planningDept == null)
            {
                return new List<Project>();
            }
            return await _context.Projects
                .Where(p => p.Deptno == planningDept.Deptno)
                .ToListAsync();
        }
        //method Get project with no employee
        public async Task<IEnumerable<Project>> GetProjectsWithNoEmployees()
        {
            var projectWithEmployee = _context.Worksons
                .Select(wo => wo.Projno).Distinct().ToList();
                return await _context.Projects
                .Where(p => !projectWithEmployee.Contains(p.Projno))
                .ToListAsync();
        }
        public async Task<IEnumerable<object>> GetProjectsManagedByFemaleManagers()
        {
            return await _context.Employees
                .Join(_context.Departments, e => e.Empno, d => d.Mgrempno, (e, d) => new { e, d })
                .Where(x => x.e.Sex == "Female")
                .Join(_context.Projects, x => x.d.Deptno, p => p.Deptno, (x, p) => new { x.e.Fname, x.e.Lname, p.Projname })
                .OrderBy(x => x.Fname)
                .ToListAsync();
        }
    }
}
