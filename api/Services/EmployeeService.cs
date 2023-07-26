using BloodDB.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace BloodDB.Services
{
    public class EmployeeService:IEmployeeService
    {

        private readonly BloodDbContext bloodBankContext;

        public EmployeeService(BloodDbContext bloodBankContext)
        {
            this.bloodBankContext = bloodBankContext;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await bloodBankContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int Empid)
        {
            return await bloodBankContext.Employees.FirstOrDefaultAsync(e => e.Empid == Empid);
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await bloodBankContext.Employees.AddAsync(employee);
            await bloodBankContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await bloodBankContext.Employees
                .FirstOrDefaultAsync(e => e.Empid == employee.Empid);

            if (result != null)
            {
                result.Empname = employee.Empname;
                result.Phone = employee.Phone;
                result.Email = employee.Email;
                result.Password = employee.Password;
                result.Fullname = employee.Fullname;
                result.Address = employee.Address;
                result.Donors = employee.Donors;

                await bloodBankContext.SaveChangesAsync();

                return result;
            }

            return null;
        }



        public async Task<Employee> DeleteEmployee(int employeeId)
        {
            var result = await bloodBankContext.Employees
                .FirstOrDefaultAsync(e => e.Empid == employeeId);
            if (result != null)
            {
                bloodBankContext.Employees.Remove(result);
                await bloodBankContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
