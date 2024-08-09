using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using MiniProject3.Interfaces;
using MiniProject3.Models;

namespace MiniProject3.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[Controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        /// <summary>
        /// You can Get All Employee for Company here.
        /// </summary>
        /// <remarks>
        /// All the parameters in the request body can be null. 
        ///
        ///  You can search by using any of the parameters in the request.
        ///  
        ///  NOTE: You can only search by one parameter at a time
        ///  
        /// Sample request:
        ///     GET  api/v1/Employee
        /// </remarks>
        /// <param name="GetAllEmployee"></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [MapToApiVersion("1.0")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployeesAsync()
        {
            return Ok(await _employeeService.GetAllEmployees());
        }
        /// <summary>
        /// You can Get By Id Employee for Company here.
        /// </summary>
        /// <remarks>
        /// All the parameters in the request body can be null. 
        ///
        ///  You can search by using any of the parameters in the request.
        ///  
        ///  NOTE: You can only search by one parameter at a time
        ///  
        /// Sample request:
        ///     GET  api/v1/Employee/{id}
        /// </remarks>
        /// <param name="GetEmployee"></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [MapToApiVersion("1.0")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        /// <summary>
        /// You can Add Employee for Company here.
        /// </summary>
        /// <remarks>
        /// All the parameters in the request body can be null. 
        ///
        ///  You can search by using any of the parameters in the request.
        ///  
        ///  NOTE: You can only search by one parameter at a time
        ///  
        /// Sample request:
        ///     POST  api/v1/Employee/{1}
        ///     {
        ///         "empno": 8,
        ///         "fname": "Vira",
        ///         "lname": "Miranda",
        ///         "address": "Jambi",
        ///         "dob": "1998-08-09",
        ///         "sex": "Female",
        ///         "position": "Social Media Specialist",
        ///         "deptno": 5
        ///     }
        /// </remarks>
        /// <param name="AddEmployee"></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [MapToApiVersion("1.0")]
        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            var createdEmployee = await _employeeService.AddEmployee(employee);
            return CreatedAtAction(nameof(GetEmployeeByIdAsync), new { id = createdEmployee.Empno }, createdEmployee);
        }

        /// <summary>
        /// You can Update Employee for Company here.
        /// </summary>
        /// <remarks>
        /// All the parameters in the request body can be null. 
        ///
        ///  You can search by using any of the parameters in the request.
        ///  
        ///  NOTE: You can only search by one parameter at a time
        ///  
        /// Sample request:
        ///     PUT  api/v1/Employee
        ///     {
        ///         "empno": 8,
        ///         "fname": "Vira",
        ///         "lname": "Miranda",
        ///         "address": "Jambi",
        ///         "dob": "1998-08-09",
        ///         "sex": "Female",
        ///         "position": "Social Media Specialist",
        ///         "deptno": 5
        ///     }
        /// </remarks>
        /// <param name="UpdateEmployee"></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [MapToApiVersion("1.0")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
        {
            if (id != employee.Empno)
            {
                return BadRequest();
            }

            var updatedEmployee = await _employeeService.UpdateEmployee(employee);
            if (updatedEmployee == null)
            {
                return NotFound();
            }

            return NoContent();
        }
        /// <summary>
        /// You Delete Employee for Company here.
        /// </summary>
        /// <remarks>
        /// All the parameters in the request body can be null. 
        ///
        ///  You can search by using any of the parameters in the request.
        ///  
        ///  NOTE: You can only search by one parameter at a time
        ///  
        /// Sample request:
        ///     DELETE  api/v1/Employee/{id}
        /// </remarks>
        /// <param name="DeleteEmployee"></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [MapToApiVersion("1.0")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var deleted = await _employeeService.DeleteEmployee(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        // additional method controller

        /// <summary>
        /// You can Get employee Address BRICS Employee for Company here.
        /// </summary>
        /// <remarks>
        /// All the parameters in the request body can be null. 
        ///
        ///  You can search by using any of the parameters in the request.
        ///  
        ///  NOTE: You can only search by one parameter at a time
        ///  
        /// Sample request:
        ///     GET  api/v1/Employee/brics
        /// </remarks>
        /// <param name=""></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [MapToApiVersion("1.0")]
        [HttpGet("brics")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesBrics()
        {
            return Ok(await _employeeService.GetEmployeesBrics());
        }
        /// <summary>
        /// You can Get employee Address BRICS Employee for Company here.
        /// </summary>
        /// <remarks>
        /// All the parameters in the request body can be null. 
        ///
        ///  You can search by using any of the parameters in the request.
        ///  
        ///  NOTE: You can only search by one parameter at a time
        ///  
        /// Sample request:
        ///     GET  api/v1/Employee/born-1980-1990
        /// </remarks>
        /// <param name=""></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [MapToApiVersion("1.0")]
        [HttpGet(("born-1980-1990"))]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeBornBetween1980And1990()
        {
            return Ok(await _employeeService.GetEmployeeBornBetween1980And1990());
        }
        /// <summary>
        /// You can Get employee Address BRICS Employee for Company here.
        /// </summary>
        /// <remarks>
        /// All the parameters in the request body can be null. 
        ///
        ///  You can search by using any of the parameters in the request.
        ///  
        ///  NOTE: You can only search by one parameter at a time
        ///  
        /// Sample request:
        ///     GET  api/v1/Employee/female-born-after1990
        /// </remarks>
        /// <param name=""></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [MapToApiVersion("1.0")]
        [HttpGet("female-born-after1990")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetFemaleEmployeeBornAfter1990()
        {
            return Ok(await _employeeService.GetFemaleEmployeeBornAfter1990());
        }
        /// <summary>
        /// You can Get employee Address BRICS Employee for Company here.
        /// </summary>
        /// <remarks>
        /// All the parameters in the request body can be null. 
        ///
        ///  You can search by using any of the parameters in the request.
        ///  
        ///  NOTE: You can only search by one parameter at a time
        ///  
        /// Sample request:
        ///     GET  api/v1/Employee/female-managers
        /// </remarks>
        /// <param name=""></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [MapToApiVersion("1.0")]
        [HttpGet("female-managers")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetFemaleManagers()
        {
            return Ok(await _employeeService.GetFemaleManagers());
        }
        /// <summary>
        /// You can Get employee Address BRICS Employee for Company here.
        /// </summary>
        /// <remarks>
        /// All the parameters in the request body can be null. 
        ///
        ///  You can search by using any of the parameters in the request.
        ///  
        ///  NOTE: You can only search by one parameter at a time
        ///  
        /// Sample request:
        ///     GET  api/v1/Employee/non-managers
        /// </remarks>
        /// <param name=""></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [MapToApiVersion("1.0")]

        [MapToApiVersion("1.0")]
        [HttpGet("non-managers")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetNonManagerEmployees()
        {
            return Ok(await _employeeService.GetNonManagerEmployees());
        }
    }
}
