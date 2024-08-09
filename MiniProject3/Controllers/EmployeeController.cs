using Microsoft.AspNetCore.Mvc;
using MiniProject3.Interfaces;
using MiniProject3.Models;

namespace MiniProject3.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployeesAsync()
        {
            return Ok(await _employeeService.GetAllEmployees());
        }

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

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            var createdEmployee = await _employeeService.AddEmployee(employee);
            return CreatedAtAction(nameof(GetEmployeeByIdAsync), new { id = createdEmployee.Empno }, createdEmployee);
        }

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
        [HttpGet("brics")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesBrics()
        {
            return Ok(await _employeeService.GetEmployeesBrics());
        }

        [HttpGet(("born-1980-1990"))]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeBornBetween1980And1990()
        {
            return Ok(await _employeeService.GetEmployeeBornBetween1980And1990());
        }

        [HttpGet("female-born-after1990")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetFemaleEmployeeBornAfter1990()
        {
            return Ok(await _employeeService.GetFemaleEmployeeBornAfter1990());
        }

        [HttpGet("female-managers")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetFemaleManagers()
        {
            return Ok(await _employeeService.GetFemaleManagers());
        }
        [HttpGet("non-managers")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetNonManagerEmployees()
        {
            return Ok(await _employeeService.GetNonManagerEmployees());
        }
    }
}
