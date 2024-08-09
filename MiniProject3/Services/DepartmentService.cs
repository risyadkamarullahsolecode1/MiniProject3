using Microsoft.EntityFrameworkCore;
using MiniProject3.Interfaces;
using MiniProject3.Models;

namespace MiniProject3.Services
{
    public class DepartmentService:IDepartmentService
    {
        private readonly CompanyContext _context;

        public DepartmentService(CompanyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            return await _context.Departments.FindAsync(id);
        }

        public async Task<Department> AddDepartment(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<Department> UpdateDepartment(int id, Department department)
        {
            _context.Departments.Update(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<bool> DeleteDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return false;
            }

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return true;
        }

        //method Get Department with more than 10 employee
        public async Task<IEnumerable<object>> GetDepartmentsWithMoreThan10Employees()
        {
            return await _context.Employees
                .GroupBy(e => e.Deptno)
                .Where(g => g.Count() > 10)
                .Select(g => new {Deptno = g.Key, EmployeeCount = g.Count() })
                .ToListAsync();
        }
        public async Task<IEnumerable<object>> GetEmployeeDetailsByDepartment(string departmentName)
        {
            return await _context.Employees
                .Join(_context.Departments, e => e.Deptno, d => d.Deptno, (e, d) => new { e, d })
                .Where(x => x.d.Deptname == departmentName)
                .Select(x => new
                {
                    x.e.Fname,
                    x.e.Lname,
                    x.e.Address
                })
                .ToListAsync();
        }
    }
}
