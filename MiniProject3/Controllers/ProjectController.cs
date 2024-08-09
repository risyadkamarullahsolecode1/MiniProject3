using Microsoft.AspNetCore.Mvc;
using MiniProject3.Interfaces;
using MiniProject3.Models;
using MiniProject3.Services;

namespace MiniProject3.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetAllProjects()
        {
            return Ok(await _projectService.GetAllProjects());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProjectById(int id)
        {
            var project = await _projectService.GetProjectById(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult<Project>> AddProject(Project project)
        {
            var createdProject = await _projectService.AddProject(project);
            return CreatedAtAction(nameof(GetProjectById), new { id = createdProject.Projno }, createdProject);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, Project project)
        {
            if (id != project.Projno)
            {
                return BadRequest();
            }

            var updatedProject = await _projectService.UpdateProject(id, project);
            if (updatedProject == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var deleted = await _projectService.DeleteProject(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
        //method controller
        [HttpGet("managed-byPlanning")]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjectsManagedByPlanning()
        {
            return Ok(await _projectService.GetProjectsManagedByPlanning());
        }
        [HttpGet("project-with-NoEmployee")]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjectsWithNoEmployees()
        {
            return Ok(await _projectService.GetProjectsWithNoEmployees());
        }
        [HttpGet("managed-by-FemaleManagers")]
        public async Task<ActionResult<IEnumerable<object>>> GetProjectsManagedByFemaleManagers()
        {
            return Ok(await _projectService.GetProjectsManagedByFemaleManagers());
        }
    }
}
