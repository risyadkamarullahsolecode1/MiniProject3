using MiniProject3.Models;
using System.Collections.Generic;

namespace MiniProject3.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(int id, Employee employee);
        bool DeleteEmployee(int id);

        // methods
        List<Employee> GetBricsEmployees();
        List<Employee> GetEmployeeBornBetween1980And1990();
        List<Employee> GetFemaleEmployeeBornAfter1990();
    }
}
