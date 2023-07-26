using BloodDB.Model;
using Microsoft.AspNetCore.Mvc;

namespace BloodDB.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        
        Task <Employee> GetEmployeeById (int id);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
     Task<Employee> DeleteEmployee(int employeeId);
    }
}
