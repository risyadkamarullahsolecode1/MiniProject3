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

        public List<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return _context.Employees.Find(id);
        }

        public Employee AddEmployee(Employee employee)
        {
            var departmentExists = _context.Departments.Any(d => d.Deptno == employee.Deptno);

            if (!departmentExists)
            {
                throw new Exception($"Department with Deptno {employee.Deptno} does not exist.");
            }

            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }
        public Employee UpdateEmployee(int id, Employee employee)
        {
            if (id != employee.Empno)
            {
                return null;
            }
            _context.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return employee;

        }
        public bool DeleteEmployee(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return false;
            }
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return true;
        }

        // methods
        public List<Employee> GetBricsEmployees()
        {
            var bricsCountry = new List<string> { "Brazil", "Russia", "India", "China", "South Africa" };
            return _context.Employees
                .Where(e => bricsCountry.Contains(e.Address))
                .OrderBy(e => e.Lname)
                .ToList();
        }

        public List<Employee> GetEmployeeBornBetween1980And1990()
        {
            return _context.Employees
                .Where(e => e.Dob >= new DateTime(1980,1,1) && e.Dob <= new DateTime(1990,12,31))
                .ToList();
        }

        public List<Employee> GetFemaleEmployeeBornAfter1990()
        {
            return _context.Employees
                .Where(e => e.Sex == "Female" && e.Dob > new DateTime(1990,12,31))
                .ToList();
        }
    }
}
