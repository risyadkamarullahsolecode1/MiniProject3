using Microsoft.EntityFrameworkCore;
using MiniProject3.Interfaces;
using MiniProject3.Models;

namespace MiniProject3.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly CompanyContext _context;

        public EmployeeService(CompanyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return false;
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }

        // method
        public async Task<IEnumerable<Employee>> GetEmployeesBrics()
        {
            var bricsCountries = new List<string> { "Brazil", "Russia", "India", "China", "South Africa" };
            return await _context.Employees
                                 .Where(e => bricsCountries.Contains(e.Address))
                                 .OrderBy(e => e.Lname)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployeeBornBetween1980And1990()
        {
            return await _context.Employees
                                 .Where(e => e.Dob >= new DateTime(1980, 1, 1) && e.Dob <= new DateTime(1990, 12, 31))
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetFemaleEmployeeBornAfter1990()
        {
            return await _context.Employees
                                 .Where(e => e.Sex == "Female" && e.Dob > new DateTime(1990, 12, 31))
                                 .ToListAsync();
        }
        
        public async Task<IEnumerable<Employee>> GetFemaleManagers()
        {
            return await _context.Employees
                .Join(_context.Departments, e=> e.Empno, d => d.Mgrempno, (e,d) => e)
                .Where(e => e.Sex == "Female")
                .OrderBy(e=> e.Fname)
                .ThenBy(e => e.Lname).ToListAsync();
        }
        public async Task<IEnumerable<Employee>> GetNonManagerEmployees()
        {
            var managers = _context.Departments.Select(d => d.Mgrempno).ToList();
            return await _context.Employees
                .Where(e => !managers.Contains(e.Empno))
                .ToListAsync();
        }
       
    }
}
