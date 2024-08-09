using MiniProject3.Models;

namespace MiniProject3.Interfaces
{
    public interface IDepartmentService
    {
        List<Department> GetAllDepartments();
        Department GetDepartmentById(int id);
        Department AddDepartment(Department department);
        Department UpdateDepartment(int id, Department department);
        bool DeleteDepartment(int id);

    }
}
