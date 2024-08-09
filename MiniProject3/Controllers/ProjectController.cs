using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using MiniProject3.Interfaces;
using MiniProject3.Models;
using MiniProject3.Services;

namespace MiniProject3.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[Controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        /// <summary>
        /// You can Add Project for Company here.
        /// </summary>
        /// <remarks>
        /// All the parameters in the request body can be null. 
        ///
        ///  You can search by using any of the parameters in the request.
        ///  
        ///  NOTE: You can only search by one parameter at a time
        ///  
        /// Sample request:
        ///     GET  api/v1/Project
        /// </remarks>
        /// <param name="UpdateProject"></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [MapToApiVersion("1.0")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetAllProjects()
        {
            return Ok(await _projectService.GetAllProjects());
        }
        /// <summary>
        /// You can Add Project for Company here.
        /// </summary>
        /// <remarks>
        /// All the parameters in the request body can be null. 
        ///
        ///  You can search by using any of the parameters in the request.
        ///  
        ///  NOTE: You can only search by one parameter at a time
        ///  
        /// Sample request:
        ///     GET  api/v1/Project/{id}
        /// </remarks>
        /// <param name="UpdateProject"></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [MapToApiVersion("1.0")]
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
        /// <summary>
        /// You can Add Project for Company here.
        /// </summary>
        /// <remarks>
        /// All the parameters in the request body can be null. 
        ///
        ///  You can search by using any of the parameters in the request.
        ///  
        ///  NOTE: You can only search by one parameter at a time
        ///  
        /// Sample request:
        ///     POST  api/v1/Project
        ///    {
        ///    "projno": 3,
        ///    "projname": "Web Application",
        ///    "deptno": 3
        ///    }
        /// </remarks>
        /// <param name="AddProject"></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [MapToApiVersion("1.0")]
        [HttpPost]
        public async Task<ActionResult<Project>> AddProject(Project project)
        {
            var createdProject = await _projectService.AddProject(project);
            return CreatedAtAction(nameof(GetProjectById), new { id = createdProject.Projno }, createdProject);
        }
        /// <summary>
        /// You can Add Project for Company here.
        /// </summary>
        /// <remarks>
        /// All the parameters in the request body can be null. 
        ///
        ///  You can search by using any of the parameters in the request.
        ///  
        ///  NOTE: You can only search by one parameter at a time
        ///  
        /// Sample request:
        ///     PUT  api/v1/Project/{id}
        ///    {
        ///    "projno": 3,
        ///    "projname": "Web Application",
        ///    "deptno": 3
        ///    }
        /// </remarks>
        /// <param name="UpdateProject"></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [MapToApiVersion("1.0")]
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
        /// <summary>
        /// You can Delete Project for Company here.
        /// </summary>
        /// <remarks>
        /// All the parameters in the request body can be null. 
        ///
        ///  You can search by using any of the parameters in the request.
        ///  
        ///  NOTE: You can only search by one parameter at a time
        ///  
        /// Sample request:
        ///     DELETE  api/v1/Project/{id}
        /// </remarks>
        /// <param name="DeleteProject"></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [MapToApiVersion("1.0")]
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

        /// <summary>
        /// You can Add Project for Company here.
        /// </summary>
        /// <remarks>
        /// All the parameters in the request body can be null. 
        ///
        ///  You can search by using any of the parameters in the request.
        ///  
        ///  NOTE: You can only search by one parameter at a time
        ///  
        /// Sample request:
        ///     GET  api/v1/Project/managed-byPlanning
        /// </remarks>
        /// <param name="UpdateProject"></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [MapToApiVersion("1.0")]
        [HttpGet("managed-byPlanning")]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjectsManagedByPlanning()
        {
            return Ok(await _projectService.GetProjectsManagedByPlanning());
        }
        /// <summary>
        /// You can Add Project for Company here.
        /// </summary>
        /// <remarks>
        /// All the parameters in the request body can be null. 
        ///
        ///  You can search by using any of the parameters in the request.
        ///  
        ///  NOTE: You can only search by one parameter at a time
        ///  
        /// Sample request:
        ///     GET  api/v1/Project/project-with-NoEmployee
        /// </remarks>
        /// <param name="UpdateProject"></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [MapToApiVersion("1.0")]
        [HttpGet("project-with-NoEmployee")]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjectsWithNoEmployees()
        {
            return Ok(await _projectService.GetProjectsWithNoEmployees());
        }
        /// <summary>
        /// You can Add Project for Company here.
        /// </summary>
        /// <remarks>
        /// All the parameters in the request body can be null. 
        ///
        ///  You can search by using any of the parameters in the request.
        ///  
        ///  NOTE: You can only search by one parameter at a time
        ///  
        /// Sample request:
        ///     GET  api/v1/Project/managed-by-FemaleManagers
        /// </remarks>
        /// <param name="UpdateProject"></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [MapToApiVersion("1.0")]
        [HttpGet("managed-by-FemaleManagers")]
        public async Task<ActionResult<IEnumerable<object>>> GetProjectsManagedByFemaleManagers()
        {
            return Ok(await _projectService.GetProjectsManagedByFemaleManagers());
        }
    }
}
