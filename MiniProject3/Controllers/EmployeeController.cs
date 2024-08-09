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
            public ActionResult<List<Employee>> GetAllEmployee()
            {
                return Ok(_employeeService.GetAllEmployees());
            }

            [HttpGet("{id}")]
            public ActionResult<Employee> GetEmployeeById(int id)
            {
                var employee = _employeeService.GetEmployeeById(id);
                if (employee == null)
                {
                    return NotFound();
                }
                return Ok(employee);
            }

            [HttpPost]
            public IActionResult AddEmployee(EmployeeDto employeeDto)
            {
                var employee = new Employee
                {
                    Empno = employeeDto.Empno,
                    Fname = employeeDto.Fname,
                    Lname = employeeDto.Lname,
                    Address = employeeDto.Address,
                    Dob = employeeDto.Dob,
                    Sex = employeeDto.Sex,
                    Position = employeeDto.Position,
                    Deptno = employeeDto.Deptno
                };

                var newEmployee = _employeeService.AddEmployee(employee);
                return CreatedAtAction(nameof(GetEmployeeById), new { id = newEmployee.Empno }, newEmployee);
            }

            [HttpPut("{id}")]
            public IActionResult PutEmployee(int id, Employee employee)
            {
                var updatedEmployee = _employeeService.UpdateEmployee(id, employee);
                if (updatedEmployee == null)
                {
                    return BadRequest();
                }
                return Ok(updatedEmployee);
            }

            [HttpDelete("{id}")]
            public IActionResult DeleteEmployee(int id)
            {
                var success = _employeeService.DeleteEmployee(id);
                if (!success)
                {
                    return NotFound();
                }
                return NoContent();
            }

            [HttpGet("brics")]
            public ActionResult<List<Employee>> GetBricsEmployees()
            {
                return Ok(_employeeService.GetBricsEmployees());
            }

            [HttpGet("born1980-1990")]
            public ActionResult<List<Employee>> GetEmployeeBornBetween1980And1990()
            {
                var employees = _employeeService.GetEmployeeBornBetween1980And1990();
                return Ok(employees);
            }
            [HttpGet("female-born-after1990")]
            public ActionResult<IEnumerable<Employee>> GetFemaleEmployeeBornAfter1990()
            {
                var employees = _employeeService.GetFemaleEmployeeBornAfter1990();
                return Ok(employees);
            }
    }
}
