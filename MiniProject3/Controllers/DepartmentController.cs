using Microsoft.AspNetCore.Mvc;
using MiniProject3.Interfaces;
using MiniProject3.Models;

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
        public ActionResult<List<Department>> GetDepartments()
        {
            return Ok(_departmentService.GetAllDepartments());
        }

        [HttpGet("{id}")]
        public ActionResult<Department> GetDepartment(int id)
        {
            var department = _departmentService.GetDepartmentById(id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        [HttpPost]
        public ActionResult<Department> AddDepartment([FromBody] DepartmentDto departmentDto)
        {
            var department = new Department
            {
                Deptname = departmentDto.Deptname
            };
            var newDepartment = _departmentService.AddDepartment(department);
            return CreatedAtAction(nameof(GetDepartment), new { id = newDepartment.Deptno }, newDepartment);
        }

        [HttpPut("{id}")]
        public IActionResult PutDepartment(int id, Department department)
        {
            var updatedDepartment = _departmentService.UpdateDepartment(id, department);
            if (updatedDepartment == null)
            {
                return BadRequest();
            }
            return Ok(updatedDepartment);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            var success = _departmentService.DeleteDepartment(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
