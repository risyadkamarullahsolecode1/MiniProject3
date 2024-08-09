using Microsoft.AspNetCore.Mvc;
using MiniProject3.Interfaces;
using MiniProject3.Models;

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
        public ActionResult<List<Workson>> GetWorkOns()
        {
            return Ok(_worksonService.GetAllWorkOns());
        }

        [HttpGet("{empNo}/{projNo}")]
        public ActionResult<Workson> GetWorkOn(int empNo, int projNo)
        {
            var workOn = _worksonService.GetWorkOnById(empNo, projNo);
            if (workOn == null)
            {
                return NotFound();
            }
            return Ok(workOn);
        }

        [HttpPost]
        public ActionResult<Workson> PostWorkOn([FromBody] WorksonDto worksonDto)
        {
            var workson = new Workson
            {
                Empno = worksonDto.Empno,
                Projno = worksonDto.Projno,
                Dateworked = worksonDto.Dateworked,
                Hoursworked = worksonDto.Hoursworked
            };
            var newWorkOn = _worksonService.AddWorkOn(workson);
            return CreatedAtAction(nameof(GetWorkOn), new { empNo = newWorkOn.Empno, projNo = newWorkOn.Projno, dateWorked = newWorkOn.Dateworked }, newWorkOn);
        }

        [HttpPut("{empNo}/{projNo}")]
        public IActionResult PutWorkOn(int empNo, int projNo,Workson workOn)
        {
            var updatedWorkOn = _worksonService.UpdateWorkOn(empNo, projNo, workOn);
            if (updatedWorkOn == null)
            {
                return BadRequest();
            }
            return Ok(updatedWorkOn);
        }

        [HttpDelete("{empNo}/{projNo}")]
        public IActionResult DeleteWorkOn(int empNo, int projNo)
        {
            var success = _worksonService.DeleteWorkOn(empNo, projNo);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
