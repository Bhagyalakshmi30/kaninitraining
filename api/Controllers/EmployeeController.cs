using BloodDB.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolrNet.Utils;
using System;
using BloodDB.Services;

namespace BloodDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;


        }

        [HttpGet]

        
        public async Task<ActionResult> GetEmployees()
        {
            try
            {
                return Ok(await employeeService.GetEmployees());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        
        public async Task<ActionResult<Employee>> GetEmployeeById (int id) 
        {
            try
            {
                var result = await employeeService.GetEmployeeById(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }



        [HttpPost]

        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                    return BadRequest();

                var createdEmployee = await employeeService.AddEmployee(employee);

                return CreatedAtAction(nameof(GetEmployeeById),
                    new { id = createdEmployee.Empid }, createdEmployee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee)
        {
            try
            {
                if (id != employee.Empid)
                    return BadRequest("Employee ID mismatch");

                var employeeToUpdate = await employeeService.GetEmployeeById(id);

                if (employeeToUpdate == null)
                    return NotFound($"Employee with Id = {id} not found");

                return await employeeService.UpdateEmployee(employee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }


        [HttpDelete("{id:int}")]
        
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            try
            {
                var employeeToDelete = await employeeService.GetEmployeeById(id);

                if (employeeToDelete == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }

                return Ok(await employeeService.GetEmployees());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }


        /*
        [HttpPut("{id:int}")]
        public async Task<Employee> UpdateEmployee(int id,Employee employee)
        {
            var result = await _bloodDbContext.Employees
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

                await _bloodDbContext.SaveChangesAsync();

                return result;
            }
            return null;



        }*/




    }
}
