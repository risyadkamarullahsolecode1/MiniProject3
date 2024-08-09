using Microsoft.AspNetCore.Mvc;
using MiniProject3.Interfaces;
using MiniProject3.Models;
using MiniProject3.Services;

namespace MiniProject3.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllDepartment()
        {
            return Ok(await _departmentService.GetAllDepartments());
        }

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

        [HttpPost]
        public async Task<ActionResult<Employee>> AddDepartment(Department department)
        {
            var createdDepartment = await _departmentService.AddDepartment(department);
            return CreatedAtAction(nameof(GetDepartmentById), new { id = createdDepartment.Deptno }, createdDepartment);
        }

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
        [HttpGet("more-10-employees")]
        public async Task<ActionResult<IEnumerable<object>>> GetDepartmentsWithMoreThan10Employees()
        {
            return Ok(await _departmentService.GetDepartmentsWithMoreThan10Employees());
        }
        [HttpGet("it-Department")]
        public async Task<ActionResult<IEnumerable<object>>> GetEmployeeDetailsByDepartment()
        {
            return Ok(await _departmentService.GetEmployeeDetailsByDepartment("IT"));
        }
    }
}
