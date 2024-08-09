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
    public class WorksonController : ControllerBase
    {
        private readonly IWorksonService _worksonService;

        public WorksonController(IWorksonService worksonService)
        {
            _worksonService = worksonService;
        }
        /// <summary>
        /// You can GET Works On for Company here.
        /// </summary>
        /// <remarks>
        /// All the parameters in the request body can be null. 
        ///
        ///  You can search by using any of the parameters in the request.
        ///  
        ///  NOTE: You can only search by one parameter at a time
        ///  
        /// Sample request:
        ///     GET  api/v1/Workson
        /// </remarks>
        /// <param name="GetWorkson"></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [MapToApiVersion("1.0")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Workson>>> GetAllWorkOn()
        {
            return Ok(await _worksonService.GetAllWorkOn());
        }
        /// <summary>
        /// You can GET Works On for Company here.
        /// </summary>
        /// <remarks>
        /// All the parameters in the request body can be null. 
        ///
        ///  You can search by using any of the parameters in the request.
        ///  
        ///  NOTE: You can only search by one parameter at a time
        ///  
        /// Sample request:
        ///     GET  api/v1/Workson/{id}
        /// </remarks>
        /// <param name="GetWorkson"></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [MapToApiVersion("1.0")]
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
        /// <summary>
        /// You can Add Works On for Company here.
        /// </summary>
        /// <remarks>
        /// All the parameters in the request body can be null. 
        ///
        ///  You can search by using any of the parameters in the request.
        ///  
        ///  NOTE: You can only search by one parameter at a time
        ///  
        /// Sample request:
        ///     POST  api/v1/Workson
        ///   {
        ///    "empno": 3,
        ///    "projno": 3,
        ///    "dateworked": "2023-09-02",
        ///    "hoursworked": 60
        ///    }
        /// </remarks>
        /// <param name="AddWorkson"></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [MapToApiVersion("1.0")]
        [HttpPost]
        public async Task<ActionResult<Workson>> AddWorkOn(Workson workson)
        {
            var createdWorkson = await _worksonService.AddWorkOn(workson);
            return CreatedAtAction(nameof(GetWorkOnById), new { id = createdWorkson.Projno }, createdWorkson);
        }
        /// <summary>
        /// You can Update Works On for Company here.
        /// </summary>
        /// <remarks>
        /// All the parameters in the request body can be null. 
        ///
        ///  You can search by using any of the parameters in the request.
        ///  
        ///  NOTE: You can only search by one parameter at a time
        ///  
        /// Sample request:
        ///     PUT  api/v1/Workson/{empNo}/{projNo}
        ///   {
        ///    "empno": 3,
        ///    "projno": 3,
        ///    "dateworked": "2023-09-02",
        ///    "hoursworked": 60
        ///    }
        /// </remarks>
        /// <param name="Update ControllerWorkson"></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [MapToApiVersion("1.0")]
        [HttpPut("{empNo}/{projNo}")]
        public async Task<IActionResult> UpdateWorkOn(int empNo,int projNo, Workson workson)
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

        /// <summary>
        /// You can Delete Works On for Company here.
        /// </summary>
        /// <remarks>
        /// All the parameters in the request body can be null. 
        ///
        ///  You can search by using any of the parameters in the request.
        ///  
        ///  NOTE: You can only search by one parameter at a time
        ///  
        /// Sample request:
        ///     GET  api/v1/Workson/{empNo}/{projNo}
        /// </remarks>
        /// <param name="DeleteWorkson"></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [MapToApiVersion("1.0")]
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
