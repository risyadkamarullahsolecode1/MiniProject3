using Microsoft.AspNetCore.Mvc;
using MiniProject3.Interfaces;
using MiniProject3.Models;

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
        public ActionResult<List<Project>> GetProjects()
        {
            return Ok(_projectService.GetAllProjects());
        }

        [HttpGet("{id}")]
        public ActionResult<Project> GetProject(int id)
        {
            var project = _projectService.GetProjectById(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [HttpPost]
        public ActionResult<Project> AddProject([FromBody]ProjectDto projectDto)
        {
            var project = new Project
            {
                Projno = projectDto.Projno,
                Projname = projectDto.Projname,
                Deptno = projectDto.Deptno
            };
            var newProject = _projectService.AddProject(project);
            return CreatedAtAction(nameof(GetProject), new { id = newProject.Projno }, newProject);
        }

        [HttpPut("{id}")]
        public IActionResult PutProject(int id, Project project)
        {
            var updatedProject = _projectService.UpdateProject(id, project);
            if (updatedProject == null)
            {
                return BadRequest();
            }
            return Ok(updatedProject);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProject(int id)
        {
            var success = _projectService.DeleteProject(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
