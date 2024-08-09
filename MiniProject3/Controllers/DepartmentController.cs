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
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        /// <summary>
        /// You can Get Department for Company here.
        /// </summary>
        /// <remarks>
        /// All the parameters in the request body can be null. 
        ///
        ///  You can search by using any of the parameters in the request.
        ///  
        ///  NOTE: You can only search by one parameter at a time
        ///  
        /// Sample request:
        ///     GET  api/v1/Department
        /// </remarks>
        /// <param name="AddDepartment"></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [MapToApiVersion("1.0")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllDepartment()
        {
            return Ok(await _departmentService.GetAllDepartments());
        }
        /// <summary>
        /// You can Get Department for Company here.
        /// </summary>
        /// <remarks>
        /// All the parameters in the request body can be null. 
        ///
        ///  You can search by using any of the parameters in the request.
        ///  
        ///  NOTE: You can only search by one parameter at a time
        ///  
        /// Sample request:
        ///     GET  api/v1/Department/{id}
        /// </remarks>
        /// <param name="AddDepartment"></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [MapToApiVersion("1.0")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetDepartmentById(int id)
        {
            var employee = await _departmentService.GetDepartmentById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        /// <summary>
        /// You can Add Department for Company here.
        /// </summary>
        /// <remarks>
        /// All the parameters in the request body can be null. 
        ///
        ///  You can search by using any of the parameters in the request.
        ///  
        ///  NOTE: You can only search by one parameter at a time
        ///  
        /// Sample request:
        ///     POST  api/v1/Department
        ///     {
        ///    "deptno": 1,
        ///    "deptname": "IT",
        ///    "mgrempno": 1
        ///    }
        /// </remarks>
        /// <param name="AddDepartment"></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [MapToApiVersion("1.0")]
        [HttpPost]
        public async Task<ActionResult<Employee>> AddDepartment(Department department)
        {
            var createdDepartment = await _departmentService.AddDepartment(department);
            return CreatedAtAction(nameof(GetDepartmentById), new { id = createdDepartment.Deptno }, createdDepartment);
        }
        /// <summary>
        /// You can Update Department for Company here.
        /// </summary>
        /// <remarks>
        /// All the parameters in the request body can be null. 
        ///
        ///  You can search by using any of the parameters in the request.
        ///  
        ///  NOTE: You can only search by one parameter at a time
        ///  
        /// Sample request:
        ///     PUT  api/v1/Department/{1}
        ///     {
        ///    "deptno": 1,
        ///    "deptname": "IT",
        ///    "mgrempno": 1
        ///    }
        /// </remarks>
        /// <param name="AddDepartment"></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [MapToApiVersion("1.0")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, Department department)
        {
            if (id != department.Deptno)
            {
                return BadRequest();
            }

            var updatedDepartment = await _departmentService.UpdateDepartment(id, department);
            if (updatedDepartment == null)
            {
                return NotFound();
            }
            return NoContent();
        }
        /// <summary>
        /// You can Add Department for Company here.
        /// </summary>
        /// <remarks>
        /// All the parameters in the request body can be null. 
        ///
        ///  You can search by using any of the parameters in the request.
        ///  
        ///  NOTE: You can only search by one parameter at a time
        ///  
        /// Sample request:
        ///     DELETE  api/v1/Department/{id}
        /// </remarks>
        /// <param name=""></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [MapToApiVersion("1.0")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var deleted = await _departmentService.DeleteDepartment(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
        //additional method controller
        /// <summary>
        /// You can Add Department for Company here.
        /// </summary>
        /// <remarks>
        /// All the parameters in the request body can be null. 
        ///
        ///  You can search by using any of the parameters in the request.
        ///  
        ///  NOTE: You can only search by one parameter at a time
        ///  
        /// Sample request:
        ///     GET  api/v1/Department/more-10-employees
        /// </remarks>
        /// <param name=""></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [MapToApiVersion("1.0")]
        [HttpGet("more-10-employees")]
        public async Task<ActionResult<IEnumerable<object>>> GetDepartmentsWithMoreThan10Employees()
        {
            return Ok(await _departmentService.GetDepartmentsWithMoreThan10Employees());
        }
        /// <summary>
        /// You can Add Department for Company here.
        /// </summary>
        /// <remarks>
        /// All the parameters in the request body can be null. 
        ///
        ///  You can search by using any of the parameters in the request.
        ///  
        ///  NOTE: You can only search by one parameter at a time
        ///  
        /// Sample request:
        ///     GET  api/v1/Department/it-Department
        /// </remarks>
        /// <param name="AddDepartment"></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [MapToApiVersion("1.0")]
        [HttpGet("it-Department")]
        public async Task<ActionResult<IEnumerable<object>>> GetEmployeeDetailsByDepartment()
        {
            return Ok(await _departmentService.GetEmployeeDetailsByDepartment("IT"));
        }
    }
}
