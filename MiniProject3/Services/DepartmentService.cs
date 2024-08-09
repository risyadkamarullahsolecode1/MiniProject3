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

        public List<Department> GetAllDepartments()
        {
            return _context.Departments.ToList();
        }

        public Department GetDepartmentById(int id)
        {
            return _context.Departments.Find(id);
        }

        public Department AddDepartment(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
            return department;
        }

        public Department UpdateDepartment(int id, Department department)
        {
            if (id != department.Deptno)
            {
                return null;
            }

            _context.Entry(department).State = EntityState.Modified;
            _context.SaveChanges();
            return department;
        }

        public bool DeleteDepartment(int id)
        {
            var department = _context.Departments.Find(id);
            if (department == null)
            {
                return false;
            }

            _context.Departments.Remove(department);
            _context.SaveChanges();
            return true;
        }

    }
}
