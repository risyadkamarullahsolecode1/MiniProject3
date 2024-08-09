using MiniProject3.Models;

namespace MiniProject3.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAllDepartments();
        Task<Department> GetDepartmentById(int id);
        Task<Department> AddDepartment(Department department);
        Task<Department> UpdateDepartment(int id, Department department);
        Task<bool> DeleteDepartment(int id);

        //method
        Task<IEnumerable<object>> GetDepartmentsWithMoreThan10Employees();
        Task<IEnumerable<object>> GetEmployeeDetailsByDepartment(string departmentName);
    }
}
