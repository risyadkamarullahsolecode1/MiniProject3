using MiniProject3.Models;
using System.Collections.Generic;

namespace MiniProject3.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(int id);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<bool> DeleteEmployee(int id);

        // method
        Task<IEnumerable<Employee>> GetEmployeesBrics();
        Task<IEnumerable<Employee>> GetEmployeeBornBetween1980And1990();
        Task<IEnumerable<Employee>> GetFemaleEmployeeBornAfter1990();
        Task <IEnumerable<Employee>> GetFemaleManagers();
        Task <IEnumerable<Employee>> GetNonManagerEmployees();
    }
}
