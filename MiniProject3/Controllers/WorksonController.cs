using Microsoft.AspNetCore.Mvc;
using MiniProject3.Interfaces;
using MiniProject3.Models;
using MiniProject3.Services;

namespace MiniProject3.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class WorksonController : ControllerBase
    {
        private readonly IWorksonService _worksonService;

        public WorksonController(IWorksonService worksonService)
        {
            _worksonService = worksonService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Workson>>> GetAllProjects()
        {
            return Ok(await _worksonService.GetAllWorkOn());
        }

        [HttpGet("{empNo}/{projNo}")]
        public async Task<ActionResult<Workson>> GetWorkOnById(int empNo, int projNo)
        {
            var project = await _worksonService.GetWorkOnById(empNo, projNo);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult<Workson>> AddProject(Workson workson)
        {
            var createdWorkson = await _worksonService.AddWorkOn(workson);
            return CreatedAtAction(nameof(GetWorkOnById), new { id = createdWorkson.Projno }, createdWorkson);
        }

        [HttpPut("{empNo}/{projNo}")]
        public async Task<IActionResult> UpdateProject(int empNo,int projNo, Workson workson)
        {
            if (empNo != workson.Empno)
            {
                return BadRequest();
            }

            var updatedWorkson = await _worksonService.UpdateWorkOn(empNo, projNo, workson);
            if (updatedWorkson == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{empNo}/{projNo}")]
        public async Task<IActionResult> DeleteWorkOn(int empNo, int projNo)
        {
            var deleted = await _worksonService.DeleteWorkOn(empNo, projNo);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
