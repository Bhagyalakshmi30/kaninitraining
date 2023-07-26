using BloodDB.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolrNet.Utils;
using System;
using BloodDB.Services;
using System.Drawing;

namespace BloodDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorController : ControllerBase
    {
        private readonly IDonorService donorService;
        public DonorController(IEmployeeService employeeService)
        {
            this.donorService = donorService;


        }

        [HttpGet]


        public async Task<ActionResult> GetDonors()
        {
            try
            {
                return Ok(await donorService.GetDonors());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<Donor>> GetDonorById(int id)
        {
            try   
            {
                var result = await donorService.GetDonorById(id);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }



        [HttpPost]

        public async Task<ActionResult<Donor>> AddDonor(Donor donor)
        {
            try
            {
                if (donor == null)
                    return BadRequest();

                var createe = await donorService.AddDonor(donor);

                return CreatedAtAction(nameof(GetDonorById),
                    new { id = createe.Donorid, createe);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new donor record");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Donor>> UpdateDonor(int id, Donor donor)
        {
            try
            {
                if (id != donor.Donorid)
                    return BadRequest("donor ID mismatch");

                var donorupda = await donorService.GetDonorById(id);

                if (donorupda == null)
                    return NotFound($"Employee with Id = {id} not found");

                return await donorService.UpdateDonor(donor);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }


        [HttpDelete("{id:int}")]

        public async Task<ActionResult<Donor>> DeleteEmployee(int id)
        {
            try
            {
                var employeeToDelete = await donorService.GetDonorById(id);

                if (employeeToDelete == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }

                return Ok(await donorService.GetDonors());
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
